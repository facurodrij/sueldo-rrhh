using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sueldo_rrhh.Models;

[Index(nameof(CUIT), IsUnique = true)]
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

    [Display(Name = "Razón Social")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string RazonSocial { get; set; }

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

    [Required] [EmailAddress] public string Email { get; set; }

    [Display(Name = "Fecha de Registro")]
    [DataType(DataType.DateTime)]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public override string? ToString()
    {
        return $"{Nombre} - {CUIT}";
    }
}