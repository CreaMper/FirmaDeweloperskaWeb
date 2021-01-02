using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZespolyModel : PageModel
    {
        public firma_deweloperska_3Context db { set; get;}
        public List<Zespoly> zespoly { get; set; }
        public List<Zespoly> zespolyZlecenia { get; set; }
        public ZespolyModel (firma_deweloperska_3Context _context)
        {
            db = _context;
            zespoly = (from zespoly in this.db.Zespolies select zespoly).ToList();
        }
        public void OnGet()
        {
        }
    }
}
