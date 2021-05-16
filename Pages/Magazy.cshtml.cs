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
    public class MagazyModel : PageModel
    {
        private readonly ILogger<MagazyModel> _logger;

        public MagazyModel(ILogger<MagazyModel> logger, MECHANIKContext _context)
        {
            _logger = logger;
            this.db = _context;

        }

        private MECHANIKContext db { get; }
        public List<User> pracownik { get; set; }
        public List<User> pracownicy { get; set; }
        public List<Order> zamowienia { get; set; }
        public List<Part> czesci { get; set; }
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

            this.zamowienia = (from o in db.Orders select o).ToList();

            this.czesci = (from p in db.Parts select p).ToList();
        }
    }
}
