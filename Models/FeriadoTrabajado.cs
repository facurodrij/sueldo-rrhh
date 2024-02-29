using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class FeriadoTrabajado
{
    public int Id { get; set; }

    public int ContratoId { get; set; }
    public Contrato? Contrato { get; set; }

    public int FeriadoId { get; set; }
    public Feriado? Feriado { get; set; }

    [Display(Name = "Horas Trabajadas")]
    [Required]
    public int HorasTrabajadas { get; set; }
}