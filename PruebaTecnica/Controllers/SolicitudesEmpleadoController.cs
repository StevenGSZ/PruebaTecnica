using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Controllers
{
    public class SolicitudesEmpleadoController : Controller
    {
        private readonly PruebaTecnicaDbContext _context;

        public SolicitudesEmpleadoController(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        // GET: SolicitudesEmpleado
        public async Task<IActionResult> Index()
        {
            string EmailSession = HttpContext.Session.GetString("EmailSesion");

            return _context.Solicitudes != null ? 
                          View(await _context.Solicitudes.Where(p => p.Email.Contains(EmailSession)).ToListAsync()) :
                          Problem("Entity set 'PruebaTecnicaDbContext.Solicitudes'  is null.");
        }

        // GET: SolicitudesEmpleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Solicitudes == null)
            {
                return NotFound();
            }

            var solicitude = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitude == null)
            {
                return NotFound();
            }

            return View(solicitude);
        }

        // GET: SolicitudesEmpleado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SolicitudesEmpleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,Name,Departament,Email,Application,StartDate,FinalDate,Description,Estado")] Solicitude solicitude)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitude);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitude);
        }

        private bool SolicitudeExists(int id)
        {
          return (_context.Solicitudes?.Any(e => e.IdSolicitud == id)).GetValueOrDefault();
        }
    }
}
