using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Persona
{
    public int Id { get; set; }

    public ApplicationUser? User { get; set; }

    public Contrato? Contrato { get; set; }

    public ICollection<PersonaHistorial> PersonaHistorials { get; set; } = new List<PersonaHistorial>();
    // public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
    // public ICollection<Vacaciones> Vacaciones { get; set; } = new List<Vacaciones>();


    public override string? ToString()
    {
        return $"{PersonaHistorials.Last().NombreCompleto} - {PersonaHistorials.Last().CUIL}";
    }

    public string ToDisplay
    {
        get { return $"{PersonaHistorials.Last().NombreCompleto} - {PersonaHistorials.Last().CUIL}"; }
    }
}

public enum Genero
{
    Masculino,
    Femenino,
    Otro
}

public enum EstadoCivil
{
    Soltero,
    Casado,
    Divorciado,
    Viudo
}

public class PersonaHistorial
{
    public int Id { get; set; }

    public int PersonaId { get; set; }
    public Persona? Persona { get; set; }

    [Display(Name = "Vigente Desde")]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime VigenteDesde { get; set; } = DateTime.Now;

    [Display(Name = "Vigente Hasta")]
    [DataType(DataType.DateTime)]
    public DateTime? VigenteHasta { get; set; }

    [Display(Name = "Nombre Completo")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string NombreCompleto { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CUIL { get; set; }

    [Display(Name = "Fecha de Nacimiento")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [Display(Name = "Género")] [Required] public Genero Genero { get; set; }

    [Display(Name = "Estado Civil")]
    [Required]
    public EstadoCivil EstadoCivil { get; set; }

    [Display(Name = "Domicilio")]
    [Required]
    public string Domicilio { get; set; }

    [Display(Name = "Hijos")]
    [Required]
    [Range(0, 10)]
    public int Hijos { get; set; } = 0;

    [Display(Name = "Fecha de Ingreso")]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    [Display(Name = "Fecha de Egreso")]
    [DataType(DataType.DateTime)]
    public DateTime? FechaEgreso { get; set; }

    // Campo CVU (Clave Virtual Uniforme) de 22 dígitos (no requerido)
    [Display(Name = "CVU")]
    [StringLength(22, MinimumLength = 22)]
    public string? CVU { get; set; }

    // Campo CBU (Clave Bancaria Uniforme) de 22 dígitos (no requerido)
    [Display(Name = "CBU")]
    [StringLength(22, MinimumLength = 22)]
    public string? CBU { get; set; }
}