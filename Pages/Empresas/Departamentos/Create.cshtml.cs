using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Departamentos
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
        ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Nombre");
            return Page();
        }

        [BindProperty]
        public Departamento Departamento { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departamentos.Add(Departamento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
