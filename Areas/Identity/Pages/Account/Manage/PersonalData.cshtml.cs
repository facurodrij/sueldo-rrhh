using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sueldo_rrhh.Models;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;

namespace sueldo_rrhh.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PersonaHistorial PersonaHistorial { get; set; }

        public PersonalDataModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            PersonaHistorial = await _context.PersonasHistorial
                .Include(p => p.Persona)
                .Where(p => p.VigenteHasta == null)
                .FirstOrDefaultAsync();

            if (PersonaHistorial == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }
    }
}