using hotelapp_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace hotelapp_frontend.Controllers
{
    public class UserController : Controller
    {
        private readonly HotelAppContext _context;

        public UserController(HotelAppContext context)
        {
            _context = context;
        }

        // Trabajar Metodos de Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.RolesList = new SelectList(_context.Roles, "IDRol", "NombreRol");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Estado = true;
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al crear el usuario: " + ex.Message);
            }

            ViewBag.RolesList = new SelectList(_context.Roles, "IDRol", "NombreRol");
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.RolesList = new SelectList(_context.Roles, "IDRol", "NombreRol");
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Attach(usuario).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar los cambios: " + ex.Message);
            }

            ViewBag.RolesList = new SelectList(_context.Roles, "IDRol", "NombreRol");
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var rol = await _context.Roles.FindAsync(usuario.IDRol);
            ViewBag.NombreRol = rol?.NombreRol;

            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al eliminar el usuario: " + ex.Message);
            }

            return View();
        }
    }
}