using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas
{
    public class CreateModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(sueldo_rrhh.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public Persona Persona { get; set; } = default!;

        [BindProperty] public ApplicationUser ApplicationUser { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ApplicationUser.Email == null)
            {
                ModelState.AddModelError("ApplicationUser.Email", "El campo Email es requerido");
                return Page();
            }

            var emptyUser = new ApplicationUser();
            // Crear usuario con pass aleatorio
            var password = Guid.NewGuid().ToString();

            emptyUser.Email = ApplicationUser.Email;
            emptyUser.UserName = ApplicationUser.Email;
            emptyUser.EmailConfirmed = true;


            _context.Personas.Add(Persona);
            await _context.SaveChangesAsync();

            emptyUser.PersonaId = Persona.Id;
            var result = await _userManager.CreateAsync(emptyUser, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}