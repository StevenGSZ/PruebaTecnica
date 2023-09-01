using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PruebaTecnica.Models;
using PruebaTecnica.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace PruebaTecnica.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly PruebaTecnicaDbContext _context;

        public UsuariosController(PruebaTecnicaDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuarios != null ? 
                          View(await _context.Usuarios.Include(d => d.ObDepartamento).ToListAsync()) :
                          Problem("Entity set 'PruebaTecnicaDbContext.Usuarios'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            UsuarioVM obUsuarioVM = new UsuarioVM()
            {

                obUsuario = new Usuario(),
                obListaDepartamento = _context.Departamentos.Select(dep => new SelectListItem()
                {
                    Text = dep.Nombre,
                    Value = dep.IdDepartamento.ToString()
                }).ToList()
            };

            //List<Usuario> lista = _context.Usuarios.Include(c => c.obDepartamento).ToList();
            return View(obUsuarioVM);
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public IActionResult Create(UsuarioVM usuario)
        {
            _context.Usuarios.Add(usuario.obUsuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }
            UsuarioVM obUsuarioVM = new UsuarioVM()
            {
                obUsuario = await _context.Usuarios.FindAsync(id),
                obListaDepartamento = _context.Departamentos.Select(dep => new SelectListItem()
                {
                    Text = dep.Nombre,
                    Value = dep.IdDepartamento.ToString()
                }).ToList()
            };

            return View(obUsuarioVM);

           
            
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioVM usuario)
        {
            if (id != usuario.obUsuario.IdUsuario)
            {
                return NotFound();
            }

            _context.Usuarios.Update(usuario.obUsuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'PruebaTecnicaDbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
