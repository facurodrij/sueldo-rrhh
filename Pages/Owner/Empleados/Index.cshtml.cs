using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Empleados;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Empleado> Empleado { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Empleado = await _context.Empleados
            .Include(e => e.ApplicationUser)
            .Include(e => e.Puesto).ToListAsync();
    }
}