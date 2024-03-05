using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Empleado.Recibos;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    private readonly UserManager<ApplicationUser> _userManager;

    public DetailsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public Recibo Recibo { get; set; } = default!;

    public ApplicationUser User { get; set; } = default!;

    public Empresa Empresa { get; set; } = default!;

    public List<Concepto> Conceptos { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        User = await _userManager.GetUserAsync(HttpContext.User);

        var persona = await _context.Personas
            .Include(p => p.Contrato)
            .FirstOrDefaultAsync(m => m.User.Id == User.Id);
        if (persona == null)
            return NotFound();

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