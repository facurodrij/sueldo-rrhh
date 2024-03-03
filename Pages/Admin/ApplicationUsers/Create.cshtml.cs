using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.ApplicationUsers;

public class CreateModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public CreateModel(Data.ApplicationDbContext context, RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
        Roles = _roleManager.Roles.ToList();
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty] public ApplicationUser ApplicationUser { get; set; } = default!;

    public IList<IdentityRole> Roles { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync(string[] roles)
    {
        if (!ModelState.IsValid) return Page();

        var user = new ApplicationUser
        {
            UserName = ApplicationUser.Email,
            Email = ApplicationUser.Email,
            EmailConfirmed = ApplicationUser.EmailConfirmed,
            PhoneNumber = ApplicationUser.PhoneNumber,
            PhoneNumberConfirmed = ApplicationUser.PhoneNumberConfirmed
        };

        var result = await _userManager.CreateAsync(user, ApplicationUser.PasswordHash);

        if (result.Succeeded)
        {
            foreach (var r in roles)
            {
                var entityRole = await _roleManager.FindByIdAsync(r);
                await _userManager.AddToRoleAsync(user, entityRole.Name);
            }
        }
        else
        {
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

            return Page();
        }

        return RedirectToPage("./Index");
    }
}