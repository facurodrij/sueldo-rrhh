using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Pages.Roles;

public class DetailsModel : PageModel
{
    private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

    public DetailsModel(sueldo_rrhh.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IdentityRole IdentityRole { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        IdentityRole = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

        if (IdentityRole == null)
        {
            return NotFound();
        }
        return Page();
    }
}