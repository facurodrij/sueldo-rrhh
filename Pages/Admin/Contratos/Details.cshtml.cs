using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Contratos;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Contrato Contrato { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var contrato = await _context.Contratos.Include(c => c.CategoriaConvenio)
            .Include(c => c.Persona)
            .ThenInclude(p => p.PersonaHistorials)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (contrato == null)
            return NotFound();
        else
            Contrato = contrato;
        return Page();
    }
}