using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sueldo_rrhh.Models;

[Index(nameof(ContratoId), nameof(FeriadoId), IsUnique = true)]
public class FeriadoTrabajado
{
    public int Id { get; set; }

    public int ContratoId { get; set; }
    public Contrato? Contrato { get; set; }

    public int FeriadoId { get; set; }
    public Feriado? Feriado { get; set; }

    [Display(Name = "Horas Trabajadas")]
    [Required]
    [Range(1, 8, ErrorMessage = "Las horas trabajadas deben estar entre 1 y 8")]
    public int HorasTrabajadas { get; set; }
}