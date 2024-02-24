using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Contrato
{
    public int Id { get; set; }

    public int PersonaId { get; set; }
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
    [Range(4, 48)]
    public int HorasSemanales { get; set; } = 48;

    // Metodo para determinar si el contrato esta activo
    public bool Activo()
    {
        return FechaFin == null || FechaFin > DateTime.Now;
    }

    public override string? ToString()
    {
        return $"{Persona?.PersonaHistorials.Last().NombreCompleto} - {CategoriaConvenio?.Nombre}";
    }
}