using System.ComponentModel.DataAnnotations;
using sueldo_rrhh.Data;

namespace sueldo_rrhh.Models;

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

    // Metodo para determinar si el valor de la hora extra es 50% o 100%
    // En Argentina, esto se determina de la siguiente manera:
    // Este adicional del 50% corresponde a las horas extras realizadas en días normales de Lunes a Viernes y de Sábado hasta las 13 horas.
    // Las horas extras realizadas en días Sábados a partir de las 13 horas, Domingos y feriados, se abonarán con un adicional del 100%.
    [Display(Name = "Valor de la Hora Extra")]
    public double ValorHoraExtra
    {
        get => CalcularValorHoraExtra();
    }

    public double CalcularValorHoraExtra()
    {
        try
        {
            var feriado = _context.Feriados.Any(f => f.Fecha.Date == Fecha.Date);

            if (Fecha.DayOfWeek == DayOfWeek.Saturday && Fecha.Hour >= 13 || Fecha.DayOfWeek == DayOfWeek.Sunday ||
                feriado)
            {
                return Horas * 2;
            }

            return Horas * 1.5;
        }
        catch (NullReferenceException)
        {
            //
            return 0;
        }
    }
}