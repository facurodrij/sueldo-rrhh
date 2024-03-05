using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Empleado.Recibos;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    private readonly UserManager<ApplicationUser> _userManager;

    public IndexModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public ApplicationUser User { get; set; } = default!;
    public ICollection<Recibo> Recibo { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        // Obtener el usuario autenticado
        User = await _userManager.GetUserAsync(HttpContext.User);

        // Obtener la Persona asociada al usuario autenticado, inluido el Contrato
        var persona = await _context.Personas
            .Include(p => p.Contrato)
            .ThenInclude(c => c.Recibos)
            .FirstOrDefaultAsync(m => m.User.Id == User.Id);
        if (persona == null)
            return NotFound();

        if (persona.Contrato == null || persona.Contrato.Activo() == false)
            return NotFound();

        Recibo = persona.Contrato.Recibos;

        return Page();
    }
}