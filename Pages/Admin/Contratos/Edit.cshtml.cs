using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Contratos;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Contrato Contrato { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == id);
        if (contrato == null) return NotFound();
        Contrato = contrato;
        ViewData["CategoriaConvenioId"] = new SelectList(_context.CategoriasConvenio, "Id", "Nombre");
        ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Id");
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Contrato).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContratoExists(Contrato.Id))
                return NotFound();
            else
                throw;
        }

        return RedirectToPage("./Index");
    }

    private bool ContratoExists(int id)
    {
        return _context.Contratos.Any(e => e.Id == id);
    }
}