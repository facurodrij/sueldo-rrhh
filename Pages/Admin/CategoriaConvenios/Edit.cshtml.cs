using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.CategoriaConvenios;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
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

        if (categoriaconvenio == null) return NotFound();

        CategoriaConvenio = categoriaconvenio;
        ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre");
            return Page();
        }

        _context.Attach(CategoriaConvenio).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaConvenioExists(CategoriaConvenio.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool CategoriaConvenioExists(int id)
    {
        return _context.CategoriasConvenio.Any(e => e.Id == id);
    }
}