using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class CategoriaConvenio
{
    public int Id { get; set; }

    [Display(Name = "Nombre de la Categoría")]
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; }

    [Display(Name = "Agrupamiento")]
    [Required]
    public char Agrupamiento { get; set; }

    [Display(Name = "Suelo Básico")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Required]
    public double SueldoBasico { get; set; }

    public int ConvenioId { get; set; }
    public Convenio? Convenio { get; set; }

    public ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public override string ToString()
    {
        return $"{Nombre} {Agrupamiento}";
    }

    public string ToDisplay
    {
        get { return $"{Nombre} {Agrupamiento}"; }
    }
}