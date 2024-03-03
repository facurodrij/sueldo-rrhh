using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Feriados;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Feriado Feriado { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var feriado = await _context.Feriados.FirstOrDefaultAsync(m => m.Id == id);

        if (feriado == null)
            return NotFound();
        else
            Feriado = feriado;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var feriado = await _context.Feriados.FindAsync(id);
        if (feriado != null)
        {
            Feriado = feriado;
            _context.Feriados.Remove(Feriado);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}