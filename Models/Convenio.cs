using System.ComponentModel.DataAnnotations;


namespace sueldo_rrhh.Models;

public class Convenio
{
    // Convenio Colectivo de Trabajo (CCT)
    public int Id { get; set; }

    [Display(Name = "Nombre del Convenio")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    public ICollection<CategoriaConvenio> Categorias { get; set; } = new List<CategoriaConvenio>();
}