using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class ZleceniaModel : PageModel
    {
        public firma_deweloperska_3Context db { get; set; }
        public List<Zlecenium> zlec { get; set; }
        public ZleceniaModel (firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public void OnGet()
        {
            zlec = (from zlecenie in db.Zlecenia select zlecenie).ToList();
        }
    }
}
