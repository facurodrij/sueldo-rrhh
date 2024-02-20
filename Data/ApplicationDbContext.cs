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
    public DbSet<Area> Areas { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empresa>()
            .HasIndex(e => e.CUIT)
            .IsUnique();

        // Relación Muchos a Uno con Area: Muchas Areas pertenecen a una Empresa
        modelBuilder.Entity<Area>()
            .HasOne(a => a.Empresa)
            .WithMany(e => e.Areas)
            .HasForeignKey(a => a.EmpresaId);

        // Relación Muchos a Uno con Departamento: Muchos Departamentos pertenecen a un Area
        modelBuilder.Entity<Departamento>()
            .HasOne(d => d.Area)
            .WithMany(a => a.Departamentos)
            .HasForeignKey(d => d.AreaId);

        // Relación Muchos a Uno con Puesto: Muchos Puestos pertenecen a un Departamento
        modelBuilder.Entity<Puesto>()
            .HasOne(p => p.Departamento)
            .WithMany(d => d.Puestos)
            .HasForeignKey(p => p.DepartamentoId);

        // Relación Uno a Uno Empleado - ApplicationUser
        modelBuilder.Entity<Empleado>()
            .HasOne(e => e.ApplicationUser)
            .WithOne(u => u.Empleado)
            .HasForeignKey<Empleado>(e => e.ApplicationUserId)
            .IsRequired();
    }
}