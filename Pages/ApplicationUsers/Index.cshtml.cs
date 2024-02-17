using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.ApplicationUsers
{
    public class IndexModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public IndexModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ApplicationUser = await _context.Users.ToListAsync();
        }
    }
}
