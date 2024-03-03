using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<PersonaHistorial> PersonaHistorial { get; set; } = default!;

    public async Task OnGetAsync()
    {
        // Get the only last PersonaHistorial from the context
        PersonaHistorial = await _context.PersonasHistorial
            .Include(p => p.Persona)
            .Where(p => p.VigenteHasta == null)
            .ToListAsync();
    }
}