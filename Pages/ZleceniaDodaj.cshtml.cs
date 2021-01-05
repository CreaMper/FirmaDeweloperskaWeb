using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZlecenieDodajModel : PageModel
    {
        public List<Priorytety> prio { get; set; }
        public List<Zespoly> zesp { get; set; }
        public List<Zlecenium> zlec { get; set; }
        public firma_deweloperska_3Context db;
        public ZlecenieDodajModel (firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet()
        {
            prio = (from priorytety in db.Prioryteties select priorytety).ToList();
            zesp = (from zespoly in db.Zespolies select zespoly).ToList();
        }

        public IActionResult OnPostAdd()
        {
            Zlecenium nowy = new Zlecenium();

            nowy.PrioId = Decimal.Parse(Request.Form["formPrio"]);
            decimal zespol = Decimal.Parse(Request.Form["formZespol"]);
            nowy.ZespId = zespol;
            nowy.ZlecRozpoczecie = DateTime.Parse(Request.Form["formRozpoczecie"]);
            if (Request.Form["formZakonczono"].ToString() == "1")
            {
                nowy.ZlecZakonczono = true;
            }
            else
            {
                nowy.ZlecZakonczono = false;
            }

            nowy.ZlecOpis = Request.Form["formOpis"];

            db.Zlecenia.Add(nowy);
            db.SaveChanges();

            return RedirectToPage("/Zlecenia");
        }
    }
}
