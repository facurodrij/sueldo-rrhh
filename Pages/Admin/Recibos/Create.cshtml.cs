using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Recibos;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["ContratoId"] = new SelectList(_context.Contratos, "Id", "Id");
        return Page();
    }

    [BindProperty] public Recibo Recibo { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // Create Async el Recibo
        _context.Recibos.Add(Recibo);
        await _context.SaveChangesAsync();

        var contrato = await _context.Contratos
            .Include(c => c.Persona)
            .Include(c => c.CategoriaConvenio)
            .FirstOrDefaultAsync(c => c.Id == Recibo.ContratoId);

        var parametros = await _context.Parametros.ToListAsync();

        var dias_mes = int.Parse(parametros.First(p => p.Nombre == "dias mes").Valor);

        var periodo = DateTime.Parse(Recibo.Periodo);

        var conceptos = await _context.Conceptos.ToListAsync();

        // Filtra los conceptos que no tienen fecha o que el mes y año de la fecha igual al periodo
        conceptos = conceptos.Where(c =>
            c.Fecha == null || c.Fecha.Value.Month == periodo.Month && c.Fecha.Value.Year == periodo.Year).ToList();

        if (!Recibo.AdicionalAsistencia)
        {
            // Filtra los conceptos que no son de tipo asistencia
            conceptos = conceptos.Where(c => c.Tipo != TipoConcepto.Asistencia).ToList();
        }

        var sueldoBasico = contrato.SueldoBasico();
        if (sueldoBasico == 0)
        {
            sueldoBasico = conceptos.First(c => c.Nombre == "Sueldo básico").Valor;
        }
        // Redondear el sueldo básico a dos decimales
        //sueldoBasico = Math.Round(sueldoBasico, 2);

        // Obtener si tuvo horas extras en el periodo
        // var horasExtras = await _context.HorasExtras

        // Recibo.Detalles = new List<DetalleRecibo>();
        var sumaRemunerativa = 0m;
        var sumaNoRemunerativa = 0m;

        foreach (var concepto in conceptos.Where(c => c.Valor > 0))
        {
            var detalle = new DetalleRecibo();
            if (concepto.Nombre == "Sueldo básico")
            {
                detalle = new DetalleRecibo
                {
                    Concepto = concepto.Nombre,
                    Base = sueldoBasico / dias_mes,
                    Unidad = dias_mes,
                    Monto = sueldoBasico,
                };
                Recibo.Detalles.Add(detalle);
                sumaRemunerativa += detalle.Monto;
                continue;
            }

            if (concepto.Nombre == "Adicional por antigüedad" || concepto.Tipo == TipoConcepto.Antiguedad)
            {
                var antiguedad = periodo.Year - contrato.FechaInicio.Year;

                detalle = new DetalleRecibo
                {
                    Concepto = concepto.Nombre,
                    Base = sueldoBasico,
                    Unidad = concepto.Valor * antiguedad,
                    Monto = concepto.Valor * sueldoBasico * antiguedad,
                };
                Recibo.Detalles.Add(detalle);
                sumaRemunerativa += detalle.Monto;
                continue;
            }

            detalle = new DetalleRecibo
            {
                Concepto = concepto.Nombre,
                Base = sueldoBasico,
                Unidad = concepto.Valor,
                Monto = concepto.Valor * sueldoBasico,
            };
            Recibo.Detalles.Add(detalle);
            if (concepto.Remunerativo)
            {
                sumaRemunerativa += detalle.Monto;
            }
            else
            {
                sumaNoRemunerativa += detalle.Monto;
            }
        }

        foreach (var concepto in conceptos.Where(c => c.Valor < 0))
        {
            var detalle = new DetalleRecibo();
            if (concepto.Remunerativo)
            {
                detalle = new DetalleRecibo
                {
                    Concepto = concepto.Nombre,
                    Base = sumaRemunerativa,
                    Unidad = concepto.Valor,
                    Monto = concepto.Valor * sumaRemunerativa,
                };
            }
            else
            {
                detalle = new DetalleRecibo
                {
                    Concepto = concepto.Nombre,
                    Base = sumaRemunerativa + sumaNoRemunerativa,
                    Unidad = concepto.Valor,
                    Monto = concepto.Valor * (sumaRemunerativa + sumaNoRemunerativa),
                };
            }

            Recibo.Detalles.Add(detalle);
        }

        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}