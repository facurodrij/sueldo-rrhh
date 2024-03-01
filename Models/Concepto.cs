using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Concepto
{
    public int Id { get; set; }

    [Display(Name = "Nombre del Concepto")]
    [Required]
    public string Nombre { get; set; }

    [Display(Name = "Fecha del Concepto")]
    [DataType(DataType.DateTime)]
    public DateTime? Fecha { get; set; } // Si es nulo, es un concepto fijo

    [Display(Name = "Valor del Concepto")]
    public double Valor { get; set; } // Positivo para haberes, negativo para descuentos

    [Display(Name = "Es Remunerativo")]
    public bool Remunerativo { get; set; } = true;

    public int ConvenioId { get; set; }
    public Convenio? Convenio { get; set; }
}