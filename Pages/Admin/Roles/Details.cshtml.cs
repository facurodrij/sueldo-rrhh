using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace sueldo_rrhh.Pages.Admin.Roles;

public class DetailsModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public DetailsModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IdentityRole IdentityRole { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string? id)
    {
        if (id == null) return NotFound();

        IdentityRole = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

        if (IdentityRole == null) return NotFound();
        return Page();
    }
}