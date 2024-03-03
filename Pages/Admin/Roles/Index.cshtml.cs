using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace sueldo_rrhh.Pages.Admin.Roles;

public class IndexModel : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public IndexModel(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public IList<IdentityRole> Roles { get; set; }

    public async Task OnGetAsync()
    {
        Roles = await _roleManager.Roles.ToListAsync();
    }
}