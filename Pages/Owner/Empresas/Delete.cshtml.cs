using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Empresas;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Empresa Empresa { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var empresa = await _context.Empresas.FirstOrDefaultAsync(m => m.Id == id);

        if (empresa == null)
            return NotFound();
        else
            Empresa = empresa;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa != null)
        {
            Empresa = empresa;
            _context.Empresas.Remove(Empresa);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}