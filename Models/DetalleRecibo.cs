namespace sueldo_rrhh.Models;

public class DetalleRecibo
{
    public int Id { get; set; }

    public int ReciboId { get; set; }
    public Recibo? Recibo { get; set; }

    public string Concepto { get; set; }

    public decimal Base { get; set; } // Es el valor base del concepto, por ejemplo, el sueldo basico o bruto

    public decimal Unidad { get; set; } // Es el valor del concepto

    public decimal Monto { get; set; } // Es el valor del concepto * el sueldo basico
}