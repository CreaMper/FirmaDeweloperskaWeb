using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZespolyDodajPracownikaModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }
        public ZespolyDodajPracownikaModel (firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        [BindProperty] public string Zesp_id { get; set; }
        public List<Pracownicy> pracownicy { get; set; }
        public List<Zespoly> zespoly { get; set; }
        public static string global_zesp_id;
        public void OnGet(string zesp_id)
        {
            Zesp_id = zesp_id;
            global_zesp_id = zesp_id;
            pracownicy = (from pracownicy in db.Pracownicies where pracownicy.ZespId == null select pracownicy).ToList();
            zespoly = (from zespoly in db.Zespolies where zespoly.ZespId == int.Parse(zesp_id) select zespoly).ToList();
        }
        public IActionResult OnPostPrzypisz(int wybrany)
        {
            decimal who = Decimal.Parse(wybrany.ToString());
            decimal zesp = Decimal.Parse(global_zesp_id);
            db.Pracownicies.Find(who).ZespId = zesp;
            db.SaveChanges();
            return RedirectToPage("/ZespolySzczegoly", new { id = global_zesp_id });
        }
    }
}
