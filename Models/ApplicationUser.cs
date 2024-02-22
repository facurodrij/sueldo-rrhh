using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Models;

public class ApplicationUser : IdentityUser
{
    public int PersonaId { get; set; }
    public Persona? Persona { get; set; }
}