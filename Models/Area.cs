using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Area
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    // Relación Muchos a Uno con Empresa: Muchas Areas pertenecen a una Empresa
    public int EmpresaId { get; set; }
    public Empresa? Empresa { get; set; }

    // Relación Uno a Muchos con Departamento: Un Area tiene muchos Departamentos
    public ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}