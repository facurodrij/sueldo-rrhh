using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sueldo_rrhh.Pages.Roles;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateModel(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [BindProperty] public string RoleName { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var role = new IdentityRole(RoleName);
        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded) return RedirectToPage("./Index");

        foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error.Description);

        return Page();
    }
}