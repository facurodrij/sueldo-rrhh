using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Areas
{
    public class IndexModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public IndexModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Area> Area { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Area = await _context.Areas
                .Include(a => a.Empresa).ToListAsync();
        }
    }
}
