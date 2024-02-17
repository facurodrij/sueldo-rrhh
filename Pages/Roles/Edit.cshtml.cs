using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Pages.Roles;

public class EditModel : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public EditModel(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    [BindProperty]
    public IdentityRole IdentityRole { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        IdentityRole = await _roleManager.FindByIdAsync(id);

        if (IdentityRole == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var role = await _roleManager.FindByIdAsync(IdentityRole.Id);
        role.Name = IdentityRole.Name;
        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            return RedirectToPage("./Index");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return Page();
    }
}