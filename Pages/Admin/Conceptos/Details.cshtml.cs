using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Conceptos
{
    public class DetailsModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public DetailsModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Concepto Concepto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concepto = await _context.Conceptos.FirstOrDefaultAsync(m => m.Id == id);
            if (concepto == null)
            {
                return NotFound();
            }
            else
            {
                Concepto = concepto;
            }
            return Page();
        }
    }
}
