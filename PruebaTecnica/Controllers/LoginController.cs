using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;
using Microsoft.AspNetCore.Http;

namespace PruebaTecnica.Controllers
{
    public class LoginController : Controller
    {
        private readonly PruebaTecnicaDbContext _context;

        public LoginController(PruebaTecnicaDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HttpContext.Session.Remove("IdSesion");
            HttpContext.Session.Remove("EmailSesion");
            HttpContext.Session.Remove("AuthNav");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string contra)
        {
            if(correo == null || contra == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == correo && u.Pass == contra);
            HttpContext.Session.SetString("IdSesion", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("EmailSesion", usuario.Email);
            HttpContext.Session.SetString("AuthNav", usuario.Tipo);

            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("ErrorLogin");
        }
    }
}
