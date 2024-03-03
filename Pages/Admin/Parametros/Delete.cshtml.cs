using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Parametros;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Parametro Parametro { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var parametro = await _context.Parametros.FirstOrDefaultAsync(m => m.Id == id);

        if (parametro == null)
            return NotFound();
        else
            Parametro = parametro;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var parametro = await _context.Parametros.FindAsync(id);
        if (parametro != null)
        {
            Parametro = parametro;
            _context.Parametros.Remove(Parametro);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}