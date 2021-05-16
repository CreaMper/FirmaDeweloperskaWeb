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
    public class podgladpracownikowModel : PageModel
    {
        private readonly ILogger<podgladpracownikowModel> _logger;

        public podgladpracownikowModel(ILogger<podgladpracownikowModel> logger, MECHANIKContext _context)
        {
            _logger = logger;
            this.db = _context;

        }

        private MECHANIKContext db { get; }
        public List<User> pracownik { get; set; }
        public List <User> pracownicy { get; set; }
        [BindProperty] public string Id { get; set; }


        public void OnGet()
        {
            String logged_id = HttpContext.Session.GetString("ID");
            if (logged_id != null)
            {
                Id = logged_id;
            }
            else
            {
                Id = "0";
            }


            this.pracownicy = (from u in db.Users
                              join r in db.Roles on u.RoleId equals r.RoleId
                              select u).ToList();

            this.pracownik = (from u in db.Users
                              join r in db.Roles on u.RoleId equals r.RoleId
                              where u.UsrId == int.Parse(Id)
                              select u).ToList();
        }
    }
}
