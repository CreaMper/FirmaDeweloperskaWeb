using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirmaDeweloperskaWeb.Pages
{
    public class PracownicyModel : PageModel
    {

        private readonly ILogger<PracownicyModel> _logger;

        public PracownicyModel(ILogger<PracownicyModel> logger , MECHANIKContext _context)
        {
            _logger = logger;
            this.db = _context;

        }

        private MECHANIKContext db { get; }
        public List<User> Pracownicies { get; set; }
        

        public async Task OnGet(string action)
        {
            Action = action;
            this.Pracownicies = (from Pracownicy in this.db.Users
                              select Pracownicy).ToList();
            HttpContext.Session.SetString("ID", "0");
        }
        [BindProperty] public string Action { get; set; }

        public IActionResult OnPostLog()
        {
            String login = Request.Form["login"];
            String haslo = Request.Form["haslo"];

            var check = db.Users
                .Where(b => (b.UsrLogin == login) && (b.UsrPasswd == haslo))
                .FirstOrDefault();

            if (check != null)
            {
                HttpContext.Session.SetString("ID", check.UsrId.ToString());
                return RedirectToPage("/UserInfo");

            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
