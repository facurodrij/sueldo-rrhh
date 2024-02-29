using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Feriado
{
    public int Id { get; set; }

    [Display(Name = "Fecha")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    [Display(Name = "Motivo")]
    public string? Motivo { get; set; }

    [Display(Name = "Es Feriado Nacional")]
    public bool EsNacional { get; set; }

    public override string? ToString()
    {
        return $"{Fecha:dd/MM/yyyy}";
    }
}