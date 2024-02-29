using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sueldo_rrhh.Data;
using sueldo_rrhh.Models;

namespace sueldo_rrhh.Pages.Admin.Contratos;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Contrato> Contrato { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Contrato = await _context.Contratos
            .Include(c => c.CategoriaConvenio)
            .Include(c => c.Persona).ToListAsync();
    }
}