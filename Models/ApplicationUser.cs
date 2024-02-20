using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Models;

public class ApplicationUser : IdentityUser
{
    public Empleado? Empleado { get; set; }
}