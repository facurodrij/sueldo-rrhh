using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.CategoriaConvenios;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<CategoriaConvenio> CategoriaConvenio { get; set; } = default!;

    public async Task OnGetAsync()
    {
        CategoriaConvenio = await _context.CategoriasConvenio
            .Include(c => c.Convenio).ToListAsync();
    }
}