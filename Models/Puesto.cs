using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Puesto
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    [Display(Name = "Descripción")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Descripcion { get; set; }

    // Relación Muchos a Uno con Departamento: Muchos Puestos pertenecen a un Departamento
    public int DepartamentoId { get; set; }
    public Departamento? Departamento { get; set; }

    // Relación Uno a Muchos con Empleado: Un Puesto tiene muchos Empleados
    public ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}