using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Contrato
{
    public int Id { get; set; }

    [Display(Name = "Persona")] public int PersonaId { get; set; }
    public Persona? Persona { get; set; }

    [Display(Name = "Categoría de Convenio")]
    public int CategoriaConvenioId { get; set; }

    [Display(Name = "Categoría de Convenio")]
    public CategoriaConvenio? CategoriaConvenio { get; set; }

    [Display(Name = "Fecha de Inicio")]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime FechaInicio { get; set; }

    [Display(Name = "Fecha de Fin")]
    [DataType(DataType.DateTime)]
    public DateTime? FechaFin { get; set; }

    [Display(Name = "Horas Semanales")]
    [Required]
    public HorasSemanales HorasSemanales { get; set; }

    public ICollection<HoraExtra> HorasExtras { get; set; } = new List<HoraExtra>();

    public ICollection<FeriadoTrabajado> FeriadosTrabajados { get; set; } = new List<FeriadoTrabajado>();

    // public ICollection<Recibo> Recibos { get; set; } = new List<Recibo>();



    public bool Activo()
    {
        return FechaFin == null || FechaFin > DateTime.Now;
    }

    public override string? ToString()
    {
        return $"{Persona?.PersonaHistorials.Last().NombreCompleto} - {CategoriaConvenio?.Nombre}";
    }
}

public enum HorasSemanales
{
    [Display(Name = "Jornada Parcial (32 hs)")] Parcial = 32,
    [Display(Name = "Jornada Completa (48 hs)")] Completa = 48
}