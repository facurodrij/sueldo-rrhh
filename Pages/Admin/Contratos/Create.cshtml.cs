using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Contratos;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["CategoriaConvenioId"] = new SelectList(_context.CategoriasConvenio, "Id", "Nombre");
        ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id");
        return Page();
    }

    [BindProperty] public Contrato Contrato { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Contratos.Add(Contrato);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}