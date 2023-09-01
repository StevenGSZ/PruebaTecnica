using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models.ViewModels;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {

        private readonly PruebaTecnicaDbContext _context;

        public HomeController(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var totalUsuarios = await _context.Usuarios.CountAsync();

            var totalDepartamentos = await _context.Departamentos.CountAsync();

            var totalSolicitudes = await _context.Solicitudes.CountAsync();

            int IdUserSession = int.Parse(HttpContext.Session.GetString("IdSesion"));

            var model = new ConsultasVM()
            {
                TotalSolicitud = totalSolicitudes,
                TotalDepartament = totalDepartamentos,
                TotalUser = totalUsuarios,
                InfoUsuario = await _context.Usuarios.FindAsync(IdUserSession)
        };
            return View(model);
        }


        public IActionResult Departamentos()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult Empleados()
        {
            return View();
        }

        public IActionResult Solicitudes()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}