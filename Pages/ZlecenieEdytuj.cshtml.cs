using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZlecenieEdytujModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }
        public List<Zespoly> wybrany_zespol { get; set; }
        public List<Priorytety> wybrany_priorytet { get; set; }
        public List<Priorytety> priorytety { get; set; }
        public List<Zespoly> zespoly { get; set; }
        public List<Zlecenium> zlec { get; set; }

        public static string global_zlec_id;
        public ZlecenieEdytujModel(firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet(string zlec_id, string zlec_zesp_id, string zlec_prio)
        {
            global_zlec_id = zlec_id;
            wybrany_zespol = (from zespoly in db.Zespolies where zespoly.ZespId == Decimal.Parse(zlec_zesp_id) select zespoly).ToList();
            wybrany_priorytet = (from priorytety in db.Prioryteties where priorytety.PrioId == Decimal.Parse(zlec_prio) select priorytety).ToList();
            zespoly = (from zespoly in db.Zespolies select zespoly).ToList();
            priorytety = (from priorytety in db.Prioryteties select priorytety).ToList();
            zlec = (from zlecenie in db.Zlecenia where zlecenie.ZlecId == Decimal.Parse(zlec_id) select zlecenie).ToList();
        }

        public IActionResult OnPostEdit()
        {

            decimal who = int.Parse(global_zlec_id);
            this.db.Zlecenia.Find(who).PrioId = Decimal.Parse(Request.Form["formPrio"]);
            decimal zespol = Decimal.Parse(Request.Form["formZespol"]);
            this.db.Zlecenia.Find(who).ZespId = zespol;
            this.db.Zlecenia.Find(who).ZlecRozpoczecie = DateTime.Parse(Request.Form["formRozpoczecie"]);
            if (Request.Form["formZakonczono"].ToString() == "1")
            {
                this.db.Zlecenia.Find(who).ZlecZakonczono = true;
            }
            else
            {
                this.db.Zlecenia.Find(who).ZlecZakonczono = false;
            }
            this.db.Zlecenia.Find(who).ZlecOpis = Request.Form["formOpis"];

            this.db.SaveChanges();

            return RedirectToPage("/Zlecenia");
        }
    }
}
