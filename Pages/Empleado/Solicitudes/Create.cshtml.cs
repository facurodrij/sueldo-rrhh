using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Empleado.Solicitudes;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    private readonly UserManager<ApplicationUser> _userManager;

    public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public ApplicationUser User { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        // Obtener el usuario autenticado
        User = await _userManager.GetUserAsync(HttpContext.User);

        // Obtener la Persona asociada al usuario autenticado, inluido el Contrato
        var persona = await _context.Personas
            .Include(p => p.Contrato)
            .FirstOrDefaultAsync(m => m.User.Id == User.Id);
        if (persona == null)
            return NotFound();

        if (persona.Contrato == null || persona.Contrato.Activo() == false)
            return NotFound();

        Contrato = persona.Contrato;

        return Page();
    }

    [BindProperty] public Solicitud Solicitud { get; set; } = default!;

    public Contrato Contrato { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        // Obtener el usuario autenticado
        User = await _userManager.GetUserAsync(HttpContext.User);

        // Obtener la Persona asociada al usuario autenticado, inluido el Contrato
        var persona = await _context.Personas
            .Include(p => p.Contrato)
            .FirstOrDefaultAsync(m => m.User.Id == User.Id);
        if (persona == null)
            return NotFound();

        if (persona.Contrato == null || persona.Contrato.Activo() == false)
            return NotFound();

        Contrato = persona.Contrato;

        if (Contrato == null || Solicitud == null)
        {
            // Manejar el caso cuando Contrato o Solicitud son null
            // Por ejemplo, puedes redirigir a otra página o mostrar un mensaje de error
            return RedirectToPage("./Error");
        }

        // Crear la Solicitud
        var solicitud = new Solicitud
        {
            ContratoId = Contrato.Id,
            FechaSolicitud = DateTime.Now,
            FechaInicio = Solicitud.FechaInicio,
            FechaFin = Solicitud.FechaFin,
            Motivo = Solicitud.Motivo,
            Descripcion = Solicitud.Descripcion,
            Estado = EstadoSolicitud.Pendiente
        };

        _context.Solicitudes.Add(solicitud);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}