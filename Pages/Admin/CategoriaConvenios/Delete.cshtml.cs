using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.CategoriaConvenios;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public CategoriaConvenio CategoriaConvenio { get; set; } = default!;

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var categoriaconvenio = await _context.CategoriasConvenio.FindAsync(id);
        if (categoriaconvenio != null)
        {
            CategoriaConvenio = categoriaconvenio;
            _context.CategoriasConvenio.Remove(CategoriaConvenio);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}