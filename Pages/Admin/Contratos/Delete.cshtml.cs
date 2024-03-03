using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Contratos;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Contrato Contrato { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == id);

        if (contrato == null)
            return NotFound();
        else
            Contrato = contrato;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var contrato = await _context.Contratos.FindAsync(id);
        if (contrato != null)
        {
            Contrato = contrato;
            _context.Contratos.Remove(Contrato);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}