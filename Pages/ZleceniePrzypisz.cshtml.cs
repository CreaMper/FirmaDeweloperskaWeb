using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZleceniePrzypiszModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }
        public List<Zespoly> wybrany_zespol { get; set; }
        public List<Zespoly> wszystkie_zespoly { get; set; }
        public List<Priorytety> priorytety { get; set; }
        public static string global_id;
        public ZleceniePrzypiszModel (firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet(string zespol_id)
        {
            global_id = zespol_id;
            decimal zespol = Decimal.Parse(zespol_id);
            wybrany_zespol = (from zespoly in db.Zespolies where zespoly.ZespId == zespol select zespoly).ToList();
            priorytety = (from priorytety in db.Prioryteties select priorytety).ToList();
            wszystkie_zespoly = (from zespoly in db.Zespolies select zespoly).ToList();
        }

        public IActionResult OnPostPrzypisz()
        {
            Zlecenium nowy = new Zlecenium();
            nowy.PrioId = Decimal.Parse(Request.Form["formPrio"]);
            decimal zespol = Decimal.Parse(global_id);
            nowy.ZespId = zespol;
            nowy.ZlecRozpoczecie = DateTime.Parse(Request.Form["formRozpoczecie"]);
            string test = Request.Form["formZakonczono"].ToString();
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

            return RedirectToPage("/ZespolySzczegoly", new { id = global_id });
        }
    }
}
