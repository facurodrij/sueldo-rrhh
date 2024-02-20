using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Empleado
{
    public int Id { get; set; }

    [Display(Name = "Nombre Completo")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string NombreCompleto { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string CUIL { get; set; }

    [Display(Name = "Fecha de Nacimiento")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [Display(Name = "Género")] [Required] public string Genero { get; set; }

    [Display(Name = "Estado Civil")]
    [Required]
    public string EstadoCivil { get; set; }

    [Display(Name = "Fecha de Ingreso")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaIngreso { get; set; }

    [Display(Name = "Fecha de Egreso")]
    [DataType(DataType.Date)]
    public DateTime FechaEgreso { get; set; }

    // Relación Muchos a Uno con Puesto: Muchos Empleados pertenecen a un Puesto
    public int PuestoId { get; set; }
    public Puesto Puesto { get; set; }

    // Relación Uno a Uno con ApplicationUser (Required)
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}