using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Recibos;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Recibo Recibo { get; set; } = default!;

    public Empresa Empresa { get; set; } = default!;

    public List<Concepto> Conceptos { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var recibo = await _context.Recibos
            .Include(r => r.Contrato)
            .Include(r => r.Contrato.Persona)
            .ThenInclude(p => p.PersonaHistorials)
            .Include(r => r.Contrato.CategoriaConvenio)
            .ThenInclude(c => c.Convenio)
            .Include(r => r.Detalles)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recibo == null)
            return NotFound();
        else
            Recibo = recibo;

        Conceptos = await _context.Conceptos.ToListAsync();

        Empresa = await _context.Empresas.FirstOrDefaultAsync();
        if (Empresa == null)
            return NotFound();


        return Page();
    }
}