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

namespace sueldo_rrhh.Pages.Admin.Solicitudes
{
    public class CreateModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public CreateModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ContratoId"] =
                new SelectList(_context.Contratos
                        .Include(c => c.Persona)
                        .ThenInclude(p => p.PersonaHistorials)
                        .Include(c => c.CategoriaConvenio),
                    "Id", "ToDisplay");
            return Page();
        }

        [BindProperty] public Solicitud Solicitud { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Solicitudes.Add(Solicitud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}