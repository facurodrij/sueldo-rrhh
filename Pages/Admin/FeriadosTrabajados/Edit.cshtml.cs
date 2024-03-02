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

namespace sueldo_rrhh.Pages.Admin.FeriadosTrabajados
{
    public class EditModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public EditModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FeriadoTrabajado FeriadoTrabajado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feriadotrabajado =  await _context.FeriadosTrabajados.FirstOrDefaultAsync(m => m.Id == id);
            if (feriadotrabajado == null)
            {
                return NotFound();
            }
            FeriadoTrabajado = feriadotrabajado;
           ViewData["ContratoId"] = new SelectList(_context.Contratos, "Id", "Id");
           ViewData["FeriadoId"] = new SelectList(_context.Feriados, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FeriadoTrabajado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeriadoTrabajadoExists(FeriadoTrabajado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FeriadoTrabajadoExists(int id)
        {
            return _context.FeriadosTrabajados.Any(e => e.Id == id);
        }
    }
}
