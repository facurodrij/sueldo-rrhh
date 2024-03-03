using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Solicitudes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Solicitud> Solicitud { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Solicitud = await _context.Solicitudes
            .Include(s => s.Contrato).ToListAsync();
    }
}