using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.CategoriaConvenios;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public CategoriaConvenio CategoriaConvenio { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var categoriaconvenio = await _context.CategoriasConvenio
            .Include(c => c.Convenio)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (categoriaconvenio == null)
            return NotFound();
        else
            CategoriaConvenio = categoriaconvenio;

        return Page();
    }
}