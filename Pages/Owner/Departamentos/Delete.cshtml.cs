using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Departamentos;

public class DeleteModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public DeleteModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Departamento Departamento { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var departamento = await _context.Departamentos.Include(d => d.Area).FirstOrDefaultAsync(m => m.Id == id);

        if (departamento == null)
            return NotFound();
        else
            Departamento = departamento;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento != null)
        {
            Departamento = departamento;
            _context.Departamentos.Remove(Departamento);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}