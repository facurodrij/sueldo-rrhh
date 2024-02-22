using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sueldo_rrhh.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;

namespace sueldo_rrhh.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public Persona Persona { get; set; }

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

            Persona = await _context.Personas.FirstOrDefaultAsync(p => p.User.Id == user.Id);
            if (Persona == null)
            {
                return NotFound($"Unable to load Persona data for user with ID '{user.Id}'.");
            }

            return Page();
        }
    }
}