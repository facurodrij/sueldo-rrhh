using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Owner.Empleados;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName");
        ViewData["PuestoId"] = new SelectList(_context.Puestos, "Id", "Descripcion");
        return Page();
    }

    [BindProperty] public Empleado Empleado { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Empleados.Add(Empleado);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}