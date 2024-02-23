using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace sueldo_rrhh.Models;

public class ApplicationUser : IdentityUser
{
    public int PersonaId { get; set; }
    public Persona? Persona { get; set; }

    // Email required
    [Required]
    public override string Email { get; set; } = default!;
}