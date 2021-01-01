using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirmaDeweloperskaWeb.Pages
{
    public class PracownicyEdytujModel : PageModel
    {
        private firma_deweloperska_3Context db { get; }
        public List<Pracownicy> PracownikDane { get; set; }
        public PracownicyEdytujModel(firma_deweloperska_3Context _context)
        {
            this.db = _context;

        }
        [BindProperty] public string Id { get; set; }
        public static string global_id;
        public void OnGet(string id)
        {
            Id = id;
            global_id = id;
            this.PracownikDane = (from Pracownicy in this.db.Pracownicies
                                  where Pracownicy.PracId == int.Parse(id)
                                  select Pracownicy).ToList();
        }
        public IActionResult OnPostAdd()
        {
            decimal who = int.Parse(global_id);
            this.db.Pracownicies.Find(who).PracImie = Request.Form["formImie"];
            this.db.Pracownicies.Find(who).PracNazwisko = Request.Form["formNazwisko"];
            this.db.Pracownicies.Find(who).PracPesel = Request.Form["formPesel"];
            this.db.Pracownicies.Find(who).PracTelefon = Request.Form["formTelefon"];
            this.db.Pracownicies.Find(who).PracEmail = Request.Form["formEmail"];
            this.db.Pracownicies.Find(who).PracAdres = Request.Form["formAdres"];
            this.db.Pracownicies.Find(who).PracStanowsko = Request.Form["formStanowisko"];

            this.db.SaveChanges();

            return RedirectToPage("/PracownicySzczegoly", new { id = global_id });
        }
    }
}
