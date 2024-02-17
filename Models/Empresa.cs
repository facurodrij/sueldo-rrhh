using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    [Display(Name = "Teléfono")] [Phone] public string Telefono { get; set; }
    [EmailAddress] public string Email { get; set; }

    [Url] public string Web { get; set; }

    [Url] public string Logo { get; set; }
}