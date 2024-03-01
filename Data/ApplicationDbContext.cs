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
    public DbSet<HoraExtra> HorasExtras { get; set; }
    public DbSet<Feriado> Feriados { get; set; }
    public DbSet<FeriadoTrabajado> FeriadosTrabajados { get; set; }
    public DbSet<Parametro> Parametros { get; set; }
    public DbSet<Concepto> Conceptos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Empresa>().ToTable("Empresa");
        modelBuilder.Entity<Persona>().ToTable("Persona");
        modelBuilder.Entity<PersonaHistorial>().ToTable("PersonaHistorial");
        modelBuilder.Entity<Convenio>().ToTable("Convenio");
        modelBuilder.Entity<CategoriaConvenio>().ToTable("CategoriaConvenio");
        modelBuilder.Entity<Contrato>().ToTable("Contrato");
        modelBuilder.Entity<Feriado>().ToTable("Feriado");
        modelBuilder.Entity<HoraExtra>().ToTable("HoraExtra");
        modelBuilder.Entity<FeriadoTrabajado>().ToTable("FeriadoTrabajado");
        modelBuilder.Entity<Parametro>().ToTable("Parametro");


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
            new CategoriaConvenio
            {
                Id = 1, Nombre = "Maestranza y Servicios", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 441108.34
            },
            new CategoriaConvenio
            {
                Id = 2, Nombre = "Maestranza y Servicios", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 442385.30
            },
            new CategoriaConvenio
            {
                Id = 3, Nombre = "Maestranza y Servicios", Agrupamiento = 'C', ConvenioId = 1, SueldoBasico = 446859.17
            },
            new CategoriaConvenio
                { Id = 4, Nombre = "Administrativo", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 445901.45 },
            new CategoriaConvenio
                { Id = 5, Nombre = "Administrativo", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 447820.26 },
            new CategoriaConvenio
                { Id = 6, Nombre = "Administrativo", Agrupamiento = 'C', ConvenioId = 1, SueldoBasico = 449736.83 },
            new CategoriaConvenio
                { Id = 7, Nombre = "Administrativo", Agrupamiento = 'D', ConvenioId = 1, SueldoBasico = 455489.91 },
            new CategoriaConvenio
                { Id = 8, Nombre = "Administrativo", Agrupamiento = 'E', ConvenioId = 1, SueldoBasico = 460283.01 },
            new CategoriaConvenio
                { Id = 9, Nombre = "Administrativo", Agrupamiento = 'F', ConvenioId = 1, SueldoBasico = 467314.17 },
            new CategoriaConvenio
                { Id = 10, Nombre = "Cajero", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 447498.77 },
            new CategoriaConvenio
                { Id = 11, Nombre = "Cajero", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 449736.83 },
            new CategoriaConvenio
                { Id = 12, Nombre = "Cajero", Agrupamiento = 'C', ConvenioId = 1, SueldoBasico = 452613.37 },
            new CategoriaConvenio
                { Id = 13, Nombre = "Auxiliar", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 447498.77 },
            new CategoriaConvenio
                { Id = 14, Nombre = "Auxiliar", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 450694.55 },
            new CategoriaConvenio
                { Id = 15, Nombre = "Auxiliar", Agrupamiento = 'C', ConvenioId = 1, SueldoBasico = 461241.86 },
            new CategoriaConvenio
            {
                Id = 16, Nombre = "Auxiliar Especializado", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 451335.28
            },
            new CategoriaConvenio
            {
                Id = 17, Nombre = "Auxiliar Especializado", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 457087.23
            },
            new CategoriaConvenio
                { Id = 18, Nombre = "Vendedor", Agrupamiento = 'A', ConvenioId = 1, SueldoBasico = 447498.77 },
            new CategoriaConvenio
                { Id = 19, Nombre = "Vendedor", Agrupamiento = 'B', ConvenioId = 1, SueldoBasico = 457088.36 },
            new CategoriaConvenio
                { Id = 20, Nombre = "Vendedor", Agrupamiento = 'C', ConvenioId = 1, SueldoBasico = 460283.01 },
            new CategoriaConvenio
                { Id = 21, Nombre = "Vendedor", Agrupamiento = 'D', ConvenioId = 1, SueldoBasico = 467314.17 }
        );

        modelBuilder.Entity<Feriado>().HasData(
            new Feriado { Id = 1, Fecha = new DateTime(2021, 1, 1), Motivo = "Año Nuevo", EsNacional = true },
            new Feriado { Id = 2, Fecha = new DateTime(2021, 2, 15), Motivo = "Carnaval", EsNacional = false },
            new Feriado { Id = 3, Fecha = new DateTime(2024, 2, 13), Motivo = "Carnaval", EsNacional = false },
            new Feriado
            {
                Id = 4, Fecha = new DateTime(2024, 3, 24), Motivo = "Día de la Memoria por la Verdad y la Justicia",
                EsNacional = true
            },
            new Feriado { Id = 5, Fecha = new DateTime(2024, 3, 28), Motivo = "Jueves Santo", EsNacional = false },
            new Feriado { Id = 6, Fecha = new DateTime(2024, 3, 29), Motivo = "Viernes Santo", EsNacional = false },
            new Feriado
            {
                Id = 7, Fecha = new DateTime(2024, 4, 2),
                Motivo = "Día del Veterano y de los Caídos en la Guerra de Malvinas", EsNacional = true
            },
            new Feriado { Id = 8, Fecha = new DateTime(2024, 5, 1), Motivo = "Día del Trabajador", EsNacional = true },
            new Feriado
            {
                Id = 9, Fecha = new DateTime(2024, 5, 25), Motivo = "Día de la Revolución de Mayo", EsNacional = true
            }
        );

        // Seed Parametros
        modelBuilder.Entity<Parametro>().HasData(
            new Parametro { Id = 1, Nombre = "horas mes", Valor = "200" }
        );

        // Seed Acuerdos
        modelBuilder.Entity<Concepto>().HasData(
            new Concepto
            {
                Id = 1, ConvenioId = 1, Nombre = "Sueldo básico", Valor = 450000
            }, // Sueldo básico por defecto para el CCT
            new Concepto { Id = 2, ConvenioId = 1, Nombre = "Adicional por asistencia", Valor = 0.0833 },
            new Concepto { Id = 3, ConvenioId = 1, Nombre = "Adicional por antiguedad", Valor = 0.01 },
            new Concepto { Id = 4, ConvenioId = 1, Nombre = "Descuento jubilatorio", Valor = -0.11 },
            new Concepto { Id = 5, ConvenioId = 1, Nombre = "Descuento obra social", Valor = -0.03 },
            new Concepto { Id = 6, ConvenioId = 1, Nombre = "Descuento sindical", Valor = -0.02 },
            new Concepto { Id = 7, ConvenioId = 1, Nombre = "Descuento Ley 19.032 - INSSJP", Valor = -0.03 },
            new Concepto
            {
                Id = 8, ConvenioId = 1, Nombre = "Incremento No Remunerativo - Acuerdo Febrero 2024",
                Fecha = new DateTime(2024, 1, 1), Valor = 0.20, Remunerativo = false
            },
            new Concepto
            {
                Id = 9, ConvenioId = 1, Nombre = "Incremento No Remunerativo - Acuerdo Febrero 2024",
                Fecha = new DateTime(2024, 2, 1), Valor = 0.176, Remunerativo = false
            },
            new Concepto
            {
                Id = 10, ConvenioId = 1, Nombre = "Incremento No Remunerativo - Acuerdo Febrero 2024",
                Fecha = new DateTime(2024, 3, 1), Valor = 0.176, Remunerativo = false
            }
        );
    }
}