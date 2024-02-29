using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.ApplicationUsers;

public class DeleteModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public DeleteModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public ApplicationUser ApplicationUser { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (id == null) return NotFound();

        var applicationuser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

        if (applicationuser == null)
            return NotFound();
        else
            ApplicationUser = applicationuser;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (id == null) return NotFound();

        var applicationuser = await _context.Users.FindAsync(id);
        if (applicationuser != null)
        {
            ApplicationUser = applicationuser;
            _context.Users.Remove(ApplicationUser);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}