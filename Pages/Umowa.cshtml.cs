using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class UmowaModel : PageModel
    {
        private firma_deweloperska_3Context db { get; set; }
        public UmowaModel( firma_deweloperska_3Context _context)
        {
            db = _context;
        }
        public List<Umowy> umowy { get; set; }
        [BindProperty] public string Id { get; set; }
        public static string global_id;
        public void OnGet(string id)
        {
            Id = id;
            global_id = id;
            this.umowy = (from umowy in this.db.Umowies where umowy.PracId == int.Parse(id) select umowy).ToList();
        }

        public IActionResult OnPostAdd()
        {
            Umowy nowy = new Umowy();
            nowy.PracId = int.Parse(global_id);
            nowy.UmowaPensja = decimal.Parse(Request.Form["formKwota"]);
            nowy.UmowaOdKiedy = DateTime.Parse(Request.Form["formOd"]);
            nowy.UmowaDoKiedy = DateTime.Parse(Request.Form["formDo"]);
            db.Umowies.Add(nowy);

            db.SaveChanges();

            return RedirectToPage("/PracownicySzczegoly", new { id = global_id });
        }
        public IActionResult OnPostEdit()
        {
            decimal who = int.Parse(global_id);
            umowy = (from umowy in this.db.Umowies where umowy.PracId == int.Parse(global_id) select umowy).ToList();
            Decimal id_umowy = decimal.Parse(umowy.FirstOrDefault().UmowaId.ToString());
            this.db.Umowies.Find(id_umowy).UmowaDoKiedy = DateTime.Parse(Request.Form["formDo"]);
            this.db.Umowies.Find(id_umowy).UmowaOdKiedy = DateTime.Parse(Request.Form["formOd"]);
            this.db.Umowies.Find(id_umowy).UmowaPensja = decimal.Parse(Request.Form["formKwota"]);

            this.db.SaveChanges();

            return RedirectToPage("/PracownicySzczegoly", new { id = global_id });
        }
    }
}
