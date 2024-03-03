using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Conceptos;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Concepto Concepto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var concepto = await _context.Conceptos.FirstOrDefaultAsync(m => m.Id == id);

        if (concepto == null)
            return NotFound();
        else
            Concepto = concepto;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var concepto = await _context.Conceptos.FindAsync(id);
        if (concepto != null)
        {
            Concepto = concepto;
            _context.Conceptos.Remove(Concepto);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}