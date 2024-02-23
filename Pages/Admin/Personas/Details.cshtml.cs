using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas
{
    public class DetailsModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public DetailsModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonaHistorial PersonaHistorial { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaHistorial = await _context.PersonasHistorial
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (personaHistorial == null)
            {
                return NotFound();
            }

            PersonaHistorial = personaHistorial;

            return Page();
        }
    }
}
