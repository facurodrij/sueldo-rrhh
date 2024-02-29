using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas;

public class DeleteModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public DeleteModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public PersonaHistorial PersonaHistorial { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var personaHistorial = await _context.PersonasHistorial
            .Include(p => p.Persona)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (personaHistorial == null) return NotFound();

        PersonaHistorial = personaHistorial;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var personaHistorial = await _context.PersonasHistorial.FindAsync(id);

        var persona = await _context.Personas.FindAsync(personaHistorial.PersonaId);
        if (persona != null)
        {
            // Remove the persona from the database and cascade delete the historial
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}