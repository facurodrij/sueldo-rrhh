using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Departamentos;

public class DetailsModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public DetailsModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public Departamento Departamento { get; set; } = default!;

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
}