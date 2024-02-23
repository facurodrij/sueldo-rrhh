using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] public PersonaHistorial PersonaHistorial { get; set; } = default!;

        [BindProperty] public ApplicationUser ApplicationUser { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var persona = _context.Personas.Add(new Persona()); // Create a new Persona

                var emptyUser = new ApplicationUser()
                {
                    Email = ApplicationUser.Email,
                    UserName = ApplicationUser.Email,
                    EmailConfirmed = true,
                    Persona = persona.Entity
                }; // Create a new ApplicationUser

                var password = Guid.NewGuid().ToString(); // Generate a random password

                // Create the ApplicationUser, if it fails, add the errors to Exception and throw it
                var result = await _userManager.CreateAsync(emptyUser, password);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors.Select(e => e.Description)));
                }

                PersonaHistorial.Persona = persona.Entity; // Set the PersonaHistorial's Persona to the new Persona
                _context.PersonasHistorial.Add(PersonaHistorial); // Add the PersonaHistorial to the context

                await _context.SaveChangesAsync(); // Save the changes

                await transaction.CommitAsync(); // Commit the transaction

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await transaction.RollbackAsync(); // Rollback the transaction
                return Page();
            }
        }
    }
}