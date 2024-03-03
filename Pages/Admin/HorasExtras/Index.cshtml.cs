using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.HorasExtras;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<HoraExtra> HoraExtra { get; set; } = default!;

    public async Task OnGetAsync()
    {
        HoraExtra = await _context.HorasExtras
            .Include(h => h.Contrato).ToListAsync();
    }
}