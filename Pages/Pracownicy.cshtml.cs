using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FirmaDeweloperskaWeb.Pages
{
    public class PracownicyModel : PageModel
    {

        private readonly ILogger<PracownicyModel> _logger;

        public PracownicyModel(ILogger<PracownicyModel> logger , firma_deweloperska_3Context _context)
        {
            _logger = logger;
            this.db = _context;

        }

        private firma_deweloperska_3Context db { get; }
        public List<Pracownicy> Pracownicies { get; set; }
        

        public async Task OnGet(string action)
        {
            Action = action;
            this.Pracownicies = (from Pracownicy in this.db.Pracownicies
                              select Pracownicy).ToList();
        }
        [BindProperty] public string Action { get; set; }
    }
}
