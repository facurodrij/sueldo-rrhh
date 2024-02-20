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
    public class DeleteModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public DeleteModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Area Area { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.FirstOrDefaultAsync(m => m.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            else
            {
                Area = area;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var area = await _context.Areas.FindAsync(id);
            if (area != null)
            {
                Area = area;
                _context.Areas.Remove(Area);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
