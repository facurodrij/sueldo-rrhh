using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace sueldo_rrhh.Models;

public class Empleado
{
    public int Id { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string CUIL { get; set; }

    [Display(Name = "Nombre")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    [Display(Name = "Apellido")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Apellido { get; set; }

    [Display(Name = "Fecha de Nacimiento")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }

    [Display(Name = "Género")]
    [Required]
    public string Genero { get; set; }

    [Display(Name = "Estado Civil")]
    [Required]
    public string EstadoCivil { get; set; }

    [Display(Name = "Dirección")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Direccion { get; set; }

    [Display(Name = "Fecha de Ingreso")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaIngreso { get; set; }

    [Display(Name = "Fecha de Egreso")]
    [DataType(DataType.Date)]
    public DateTime FechaEgreso { get; set; }

    // Relación Uno a Uno con ApplicationUser (Required)
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}