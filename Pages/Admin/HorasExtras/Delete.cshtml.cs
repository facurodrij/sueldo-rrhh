using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.HorasExtras;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public HoraExtra HoraExtra { get; set; } = default!;

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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var horaextra = await _context.HorasExtras.FindAsync(id);
        if (horaextra != null)
        {
            HoraExtra = horaextra;
            _context.HorasExtras.Remove(HoraExtra);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}