using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.FeriadosTrabajados;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["ContratoId"] = new SelectList(_context.Contratos, "Id", "Id");
        ViewData["FeriadoId"] = new SelectList(_context.Feriados, "Id", "Id");
        return Page();
    }

    [BindProperty] public FeriadoTrabajado FeriadoTrabajado { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.FeriadosTrabajados.Add(FeriadoTrabajado);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}