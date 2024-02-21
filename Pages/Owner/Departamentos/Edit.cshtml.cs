using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Departamentos;

public class EditModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public EditModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Departamento Departamento { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var departamento = await _context.Departamentos.Include(d => d.Area).FirstOrDefaultAsync(m => m.Id == id);
        if (departamento == null) return NotFound();
        Departamento = departamento;
        ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Nombre");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Departamento).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DepartamentoExists(Departamento.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool DepartamentoExists(int id)
    {
        return _context.Departamentos.Any(e => e.Id == id);
    }
}