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
    public class WorkersInfoModel : PageModel
    {
        private readonly ILogger<WorkersInfoModel> _logger;

        public WorkersInfoModel(ILogger<WorkersInfoModel> logger, MECHANIKContext _context)
        {
            _logger = logger;
            this.db = _context;

        }

        private MECHANIKContext db { get; }
        public List<User> pracownik { get; set; }
        [BindProperty] public string Id { get; set; }


        public void OnGet()
        {
            String logged_id = HttpContext.Session.GetString("ID");
            if (logged_id != null)
            {
                Id = logged_id;
            } else
            {
                Id = "0";
            }
            

            String newid = HttpContext.Session.GetString("ID");

            //this.pracownik = (from User in db.Users where User.UsrId == int.Parse(Id) select User).ToList();
            this.pracownik = (from u in db.Users
                              join r in db.Roles on u.RoleId equals r.RoleId
                              where u.UsrId == int.Parse(Id)
                              select u).ToList();
        }
        
        public IActionResult OnPostPodglad()
        {
            return RedirectToPage("/PracownicySzcze234234234goly");
        }
    }
}
