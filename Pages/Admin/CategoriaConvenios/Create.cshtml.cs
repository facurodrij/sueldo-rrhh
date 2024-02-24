using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.CategoriaConvenios;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre");
        return Page();
    }

    [BindProperty] public CategoriaConvenio CategoriaConvenio { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["ConvenioId"] = new SelectList(_context.Convenios, "Id", "Nombre");
            return Page();
        }

        _context.CategoriasConvenio.Add(CategoriaConvenio);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}