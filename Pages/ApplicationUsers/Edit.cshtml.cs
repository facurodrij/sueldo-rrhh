using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace sueldo_rrhh.Pages.ApplicationUsers
{
    public class EditModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EditModel(sueldo_rrhh.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            Roles = _roleManager.Roles.ToList();
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public IList<IdentityRole> Roles { get; set; } = default!;

        public IList<string> UserRoles { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationuser =  await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (applicationuser == null)
            {
                return NotFound();
            }

            ApplicationUser = applicationuser;

            UserRoles = await _userManager.GetRolesAsync(applicationuser);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] roles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(ApplicationUser.Id);

            user.UserName = ApplicationUser.Email;
            user.Email = ApplicationUser.Email;
            user.EmailConfirmed = ApplicationUser.EmailConfirmed;
            user.PhoneNumber = ApplicationUser.PhoneNumber;
            user.PhoneNumberConfirmed = ApplicationUser.PhoneNumberConfirmed;

            if (!string.IsNullOrEmpty(ApplicationUser.PasswordHash))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                await _userManager.ResetPasswordAsync(user, token, ApplicationUser.PasswordHash);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                foreach (var r in roles)
                {
                    var entityRole = await _roleManager.FindByIdAsync(r);
                    await _userManager.AddToRoleAsync(user, entityRole.Name);
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
