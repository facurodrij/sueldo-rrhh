using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Recibo
{
    public int Id { get; set; }

    public int ContratoId { get; set; }
    public Contrato? Contrato { get; set; }

    [Display(Name = "Periodo de Pago")]
    [Required]
    [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "El formato debe ser MM/YYYY")]
    public string Periodo { get; set; }

    [Display(Name = "Fecha de Registro")]
    [DataType(DataType.DateTime)]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Display(Name = "Adicional por Asistencia")]
    public bool AdicionalAsistencia { get; set; }
}