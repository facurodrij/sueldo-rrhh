using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Pages.Roles
{
    public class DeleteModel : PageModel
    {
        private readonly sueldo_rrhh.Data.ApplicationDbContext _context;

        public DeleteModel(sueldo_rrhh.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IdentityRole IdentityRole { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);

            if (role == null)
            {
                return NotFound();
            }
            else
            {
                IdentityRole = role;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);
            if (role != null)
            {
                IdentityRole = role;
                _context.Roles.Remove(IdentityRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}