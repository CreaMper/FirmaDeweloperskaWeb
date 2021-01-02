using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZespolySzczegolyModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }
        public List<Pracownicy> pracownicy { get; set; }
        public List<Zlecenium> zlecenia { get; set; }
        public List<Zespoly> zespoly { get; set; }
        [BindProperty] public string Id { get; set; }

        public ZespolySzczegolyModel(firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet(string id)
        {
            Id = id;
            pracownicy = (from Pracownicy in db.Pracownicies where Pracownicy.ZespId == int.Parse(id) select Pracownicy).ToList();
            zlecenia = (from zlecenia in this.db.Zlecenia where zlecenia.ZespId == int.Parse(id) select zlecenia).ToList();
            zespoly = (from zespoly in this.db.Zespolies where zespoly.ZespId == int.Parse(id) select zespoly).ToList();
        }
    }
}
