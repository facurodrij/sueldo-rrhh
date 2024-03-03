using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Convenios;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Convenio Convenio { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var convenio = await _context.Convenios.FirstOrDefaultAsync(m => m.Id == id);

        if (convenio == null)
            return NotFound();
        else
            Convenio = convenio;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var convenio = await _context.Convenios.FindAsync(id);
        if (convenio != null)
        {
            Convenio = convenio;
            _context.Convenios.Remove(Convenio);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}