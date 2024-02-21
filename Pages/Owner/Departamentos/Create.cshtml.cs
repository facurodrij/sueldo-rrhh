using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Departamentos;

public class CreateModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public CreateModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Nombre");
        return Page();
    }

    [BindProperty] public Departamento Departamento { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Departamentos.Add(Departamento);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}