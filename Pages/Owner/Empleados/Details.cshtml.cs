using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Empleados;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Empleado Empleado { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var empleado = await _context.Empleados.Include(e => e.ApplicationUser).Include(e => e.Puesto)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (empleado == null)
            return NotFound();
        else
            Empleado = empleado;
        return Page();
    }
}