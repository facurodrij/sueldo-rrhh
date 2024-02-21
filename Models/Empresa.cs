using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Empresa
{
    public int Id { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CUIT { get; set; }

    [Display(Name = "Nombre de la Empresa")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    [Display(Name = "Categoría")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Categoria { get; set; }

    [Display(Name = "Dirección")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Direccion { get; set; }

    [Display(Name = "Teléfono")]
    [Required]
    [Phone]
    public string Telefono { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Fecha de Registro")]
    [DataType(DataType.Date)]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    // Relación Uno a Muchos con Area: Una Empresa tiene muchas Areas
    public ICollection<Area> Areas { get; } = new List<Area>();

    public override string? ToString()
    {
        return $"{Nombre} - {CUIT}";
    }
}