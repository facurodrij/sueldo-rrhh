using Microsoft.AspNetCore.Identity;

namespace sueldo_rrhh.Models;

public class ApplicationUser : IdentityUser
{
    // Relación Uno a Uno con Empleado (Optional)
    public Empleado? Empleado { get; set; }
}