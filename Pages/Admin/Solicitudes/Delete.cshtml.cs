using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Solicitudes
{
    public class DeleteModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public DeleteModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Solicitud Solicitud { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes.FirstOrDefaultAsync(m => m.Id == id);

            if (solicitud == null)
            {
                return NotFound();
            }
            else
            {
                Solicitud = solicitud;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud != null)
            {
                Solicitud = solicitud;
                _context.Solicitudes.Remove(Solicitud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
