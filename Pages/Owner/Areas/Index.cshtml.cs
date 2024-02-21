using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Areas;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Area> Area { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Area = await _context.Areas
            .Include(a => a.Empresa).ToListAsync();
    }
}