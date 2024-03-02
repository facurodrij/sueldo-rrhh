using System.ComponentModel.DataAnnotations;

namespace sueldo_rrhh.Models;

public class Solicitud
{
    public int Id { get; set; }

    public int ContratoId { get; set; }
    public Contrato? Contrato { get; set; }

    [Display(Name = "Fecha de Solicitud")]
    public DateTime FechaSolicitud { get; set; } = DateTime.Now;

    [Display(Name = "Fecha de Inicio")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaInicio { get; set; }

    [Display(Name = "Fecha de Fin")]
    [Required]
    [DataType(DataType.Date)]
    public DateTime FechaFin { get; set; }

    [Display(Name = "Motivo")]
    [Required]
    public MotivoSolicitud Motivo { get; set; }

    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Display(Name = "Estado")]
    public EstadoSolicitud Estado { get; set; } = EstadoSolicitud.Pendiente;
}

public enum MotivoSolicitud
{
    Vacaciones,
    Permiso,
    Licencia,
    Otro
}

public enum EstadoSolicitud
{
    Pendiente,
    Aprobada,
    Rechazada
}