using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Departamentos;

public class IndexModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public IndexModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Departamento> Departamento { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Departamento = await _context.Departamentos
            .Include(d => d.Area).ToListAsync();
    }
}