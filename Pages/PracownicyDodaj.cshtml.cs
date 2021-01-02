using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirmaDeweloperskaWeb.Pages
{
    public class PracownicySzczegolyModel : PageModel
    {
        public string Message { get; set; } = "Initial Request";
        private readonly ILogger<PracownicySzczegolyModel> _logger;
        private firma_deweloperska_3Context db { get; }
        public PracownicySzczegolyModel(ILogger<PracownicySzczegolyModel> logger, firma_deweloperska_3Context _context)
        {
            _logger = logger;
            this.db = _context;

        }
        public IActionResult OnPostAdd()
        {
            Pracownicy nowy = new Pracownicy();
            nowy.PracImie = Request.Form["formImie"];
            nowy.PracNazwisko = Request.Form["formNazwisko"];
            nowy.PracPesel = Request.Form["formPesel"];
            nowy.PracTelefon = Request.Form["formTelefon"];
            nowy.PracEmail = Request.Form["formEmail"];
            nowy.PracAdres = Request.Form["formAdres"];
            nowy.PracStanowsko = Request.Form["formStanowisko"];
            db.Pracownicies.Add(nowy);

            db.SaveChanges();

            return RedirectToPage("/Pracownicy", new { Action = "Success" });
        }


    }
}
