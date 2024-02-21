using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Departamento
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    // Relación Muchos a Uno con Area: Muchos Departamentos pertenecen a un Area
    public int AreaId { get; set; }
    public Area? Area { get; set; }

    // Relación Uno a Muchos con Puesto: Un Departamento tiene muchos Puestos
    public ICollection<Puesto> Puestos { get; } = new List<Puesto>();
}