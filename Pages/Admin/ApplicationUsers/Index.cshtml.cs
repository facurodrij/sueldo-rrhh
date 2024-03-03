using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.ApplicationUsers;

public class IndexModel : PageModel
{
    private readonly Data.ApplicationDbContext _context;

    public IndexModel(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ApplicationUser> ApplicationUser { get; set; } = default!;

    public async Task OnGetAsync()
    {
        ApplicationUser = await _context.Users.ToListAsync();
    }
}