using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Empleado.HorasExtras;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public HoraExtra HoraExtra { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var horaextra = await _context.HorasExtras.FirstOrDefaultAsync(m => m.Id == id);
        if (horaextra == null)
            return NotFound();
        else
            HoraExtra = horaextra;
        return Page();
    }
}