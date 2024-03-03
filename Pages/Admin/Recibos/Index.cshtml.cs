using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Recibos;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Recibo> Recibo { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Recibo = await _context.Recibos
            .Include(r => r.Contrato).ToListAsync();
    }
}