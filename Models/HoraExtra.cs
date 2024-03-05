using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;

namespace sueldo_rrhh.Models;

[Index(nameof(Fecha), nameof(ContratoId), IsUnique = true)]
public class HoraExtra
{
    private readonly ApplicationDbContext _context;

    public int Id { get; set; }

    [Display(Name = "Fecha")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    // No se pueden superar las 3 horas extras por día o las 30 por mes.
    [Display(Name = "Cantidad de Horas")]
    [Required]
    [Range(1, 3)]
    public int Horas { get; set; }

    public int ContratoId { get; set; }
    public Contrato? Contrato { get; set; }

    public override string? ToString()
    {
        return $"{Fecha:dd/MM/yyyy} - {Horas}hs";
    }

    [Display(Name = "Es al 100%")] public bool CienPorciento { get; set; }
}