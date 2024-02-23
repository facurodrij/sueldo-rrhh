using sueldo_rrhh.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace sueldo_rrhh.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<PersonaHistorial> PersonasHistorial { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empresa>().ToTable("Empresa");
        modelBuilder.Entity<Persona>().ToTable("Persona");
        modelBuilder.Entity<PersonaHistorial>().ToTable("PersonaHistorial");
    }
}