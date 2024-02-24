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

    public DbSet<Convenio> Convenios { get; set; }

    public DbSet<CategoriaConvenio> CategoriasConvenio { get; set; }

    public DbSet<Contrato> Contratos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empresa>().ToTable("Empresa");
        modelBuilder.Entity<Persona>().ToTable("Persona");
        modelBuilder.Entity<PersonaHistorial>().ToTable("PersonaHistorial");
        modelBuilder.Entity<Convenio>().ToTable("Convenio");
        modelBuilder.Entity<CategoriaConvenio>().ToTable("CategoriaConvenio");
        modelBuilder.Entity<Contrato>().ToTable("Contrato");

        modelBuilder.Entity<Empresa>().HasIndex(e => e.CUIT).IsUnique();
        modelBuilder.Entity<Empresa>().HasData(
            new Empresa
            {
                Id = 1, CUIT = "12345678901", Nombre = "StockCar", RazonSocial = "StockCar SA", Categoria = "Comercio",
                Direccion = "Direccion 1", Telefono = "123456789", Email = "stockcar@localhost",
                FechaRegistro = DateTime.Now
            }
        );

        modelBuilder.Entity<Persona>().HasData(
            new Persona { Id = 1 }
        );

        modelBuilder.Entity<PersonaHistorial>().HasData(
            new PersonaHistorial
            {
                Id = 1, PersonaId = 1, NombreCompleto = "Admin", CUIL = "20345678901",
                FechaNacimiento = new DateTime(2000, 10, 18), Genero = Genero.Masculino,
                EstadoCivil = EstadoCivil.Soltero, Domicilio = "Direccion 2", Hijos = 0, FechaIngreso = DateTime.Now
            }
        );

        // Seed Convenio and CategoriaConvenio of CCT 130/75
        // https://www.argentina.gob.ar/sites/default/files/mteyss-ese-conveniocolectivodetrabajo-comercio-130-75.pdf

        modelBuilder.Entity<Convenio>().HasData(
            new Convenio { Id = 1, Nombre = "Comercio (CCT 130/75)", }
        );

        modelBuilder.Entity<CategoriaConvenio>().HasData(
            new CategoriaConvenio { Id = 1, Nombre = "Maestranza y Servicios", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 2, Nombre = "Maestranza y Servicios", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 3, Nombre = "Maestranza y Servicios", Agrupamiento = 'C', ConvenioId = 1 },
            new CategoriaConvenio { Id = 4, Nombre = "Administrativo", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 5, Nombre = "Administrativo", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 6, Nombre = "Administrativo", Agrupamiento = 'C', ConvenioId = 1 },
            new CategoriaConvenio { Id = 7, Nombre = "Administrativo", Agrupamiento = 'D', ConvenioId = 1 },
            new CategoriaConvenio { Id = 8, Nombre = "Administrativo", Agrupamiento = 'E', ConvenioId = 1 },
            new CategoriaConvenio { Id = 9, Nombre = "Administrativo", Agrupamiento = 'F', ConvenioId = 1 },
            new CategoriaConvenio { Id = 10, Nombre = "Cajero", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 11, Nombre = "Cajero", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 12, Nombre = "Cajero", Agrupamiento = 'C', ConvenioId = 1 },
            new CategoriaConvenio { Id = 13, Nombre = "Auxiliar", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 14, Nombre = "Auxiliar", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 15, Nombre = "Auxiliar", Agrupamiento = 'C', ConvenioId = 1 },
            new CategoriaConvenio { Id = 16, Nombre = "Auxiliar Especializado", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 17, Nombre = "Auxiliar Especializado", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 18, Nombre = "Vendedor", Agrupamiento = 'A', ConvenioId = 1 },
            new CategoriaConvenio { Id = 19, Nombre = "Vendedor", Agrupamiento = 'B', ConvenioId = 1 },
            new CategoriaConvenio { Id = 20, Nombre = "Vendedor", Agrupamiento = 'C', ConvenioId = 1 },
            new CategoriaConvenio { Id = 21, Nombre = "Vendedor", Agrupamiento = 'D', ConvenioId = 1 }
        );
    }
}