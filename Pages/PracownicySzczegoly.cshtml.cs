using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirmaDeweloperskaWeb.Pages
{
    public class PracownikSzczegolyModel : PageModel
    {
        
        private firma_deweloperska_3Context db { get; }

        public PracownikSzczegolyModel( firma_deweloperska_3Context _context)
        {
            this.db = _context;

        }
        public List<Pracownicy> PracownikDane { get; set; }
        public List<Umowy> PracownikUmowa { get; set; }
        public List<Wydatki> PracownikWydatki { get; set; }
        public List<Zespoly> PracownikZespoly { get; set; }
        [BindProperty] public string Id { get; set; }
        public void OnGet(string id)
        {
            Id = id;
            this.PracownikDane = (from Pracownicy in this.db.Pracownicies
                                 where Pracownicy.PracId == int.Parse(id)
                                  select Pracownicy).ToList();

            this.PracownikUmowa = (from Umowa in this.db.Umowies where Umowa.PracId == int.Parse(id) select Umowa).ToList();
            this.PracownikWydatki = (from Wydatki in this.db.Wydatkis where Wydatki.PracId == int.Parse(id) select Wydatki).ToList();
            this.PracownikZespoly = (from Zespoly in this.db.Zespolies join p in db.Pracownicies on Zespoly.ZespId equals p.ZespId where p.PracId == int.Parse(id) select Zespoly).ToList();
        }
        
    }

}
