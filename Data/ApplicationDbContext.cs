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
    public DbSet<Empleado> Empleados { get; set; }
    // public DbSet<Recibo> Recibos { get; set; } Aun no implementado

    // Empleados y IndentityUser tienen relación uno a uno
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Empleado>()
            .HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<Empleado>(e => e.UserId)
            .IsRequired();
    }
}