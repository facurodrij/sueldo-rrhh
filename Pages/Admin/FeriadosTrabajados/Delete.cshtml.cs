using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.FeriadosTrabajados;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public FeriadoTrabajado FeriadoTrabajado { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var feriadotrabajado = await _context.FeriadosTrabajados.FirstOrDefaultAsync(m => m.Id == id);

        if (feriadotrabajado == null)
            return NotFound();
        else
            FeriadoTrabajado = feriadotrabajado;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var feriadotrabajado = await _context.FeriadosTrabajados.FindAsync(id);
        if (feriadotrabajado != null)
        {
            FeriadoTrabajado = feriadotrabajado;
            _context.FeriadosTrabajados.Remove(FeriadoTrabajado);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}