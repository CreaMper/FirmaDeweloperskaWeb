using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZespolyDodajModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }

        public ZespolyDodajModel (firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostAdd()
        {
            Zespoly nowy = new Zespoly();
            nowy.ZespNazwa = Request.Form["formNazwa"];
            db.Zespolies.Add(nowy);

            db.SaveChanges();

            return RedirectToPage("/Zespoly");
        }
    }
}
