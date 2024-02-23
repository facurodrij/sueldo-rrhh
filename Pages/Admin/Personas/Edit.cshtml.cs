using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Personas
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty] public PersonaHistorial PersonaHistorial { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaHistorial = await _context.PersonasHistorial
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (personaHistorial == null || personaHistorial.VigenteHasta != null) // Si el historial no existe o ya no es vigente
            {
                return NotFound();
            }

            PersonaHistorial = personaHistorial;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Actualizar el campo VigenteHasta del historial actual
                var historialActual = await _context.PersonasHistorial
                    .Include(p => p.Persona)
                    .FirstOrDefaultAsync(m => m.Id == PersonaHistorial.Id);

                if (historialActual != null)
                {
                    historialActual.VigenteHasta = DateTime.Now;
                    _context.PersonasHistorial.Update(historialActual);
                }

                await _context.SaveChangesAsync();

                // Crear un nuevo historial con los datos recibidos del formulario

                var historialNuevo = new PersonaHistorial
                {
                    PersonaId = historialActual.PersonaId,
                    NombreCompleto = PersonaHistorial.NombreCompleto,
                    CUIL = PersonaHistorial.CUIL,
                    FechaNacimiento = PersonaHistorial.FechaNacimiento,
                    Genero = PersonaHistorial.Genero,
                    EstadoCivil = PersonaHistorial.EstadoCivil,
                    Domicilio = PersonaHistorial.Domicilio,
                    Hijos = PersonaHistorial.Hijos,
                    FechaIngreso = PersonaHistorial.FechaIngreso,
                    FechaEgreso = PersonaHistorial.FechaEgreso,
                    CVU = PersonaHistorial.CVU,
                    CBU = PersonaHistorial.CBU
                };

                _context.PersonasHistorial.Add(historialNuevo);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaHistorialExists(PersonaHistorial.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonaHistorialExists(int id)
        {
            return _context.PersonasHistorial.Any(e => e.Id == id);
        }
    }
}