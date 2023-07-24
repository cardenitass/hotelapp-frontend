using hotelapp_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace hotelapp_frontend.Controllers
{
    public class UserController : Controller
    {
        private readonly HotelAppContext _context;

        public UserController(HotelAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var roles = _context.Roles.ToList();
            ViewBag.RolesList = new SelectList(roles, "IDRol", "NombreRol");
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(usuario);
                }
            }
            catch
            {
                return View(usuario);
            }
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

            var rolesList = _context.Roles.ToList();
            ViewBag.RolesList = new SelectList(rolesList, "IDRol", "NombreRol");
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuarioExistente = await _context.Usuarios.FindAsync(usuario.IDUsuario);
                    if (usuarioExistente == null)
                    {
                        return NotFound();
                    }

                    // Actualizar las propiedades del usuario existente con los nuevos valores del formulario
                    usuarioExistente.Nombre = usuario.Nombre;
                    usuarioExistente.FechaNacimiento = usuario.FechaNacimiento;
                    usuarioExistente.Correo = usuario.Correo;
                    usuarioExistente.Contrasena = usuario.Contrasena;
                    usuarioExistente.Estado = usuario.Estado;
                    usuarioExistente.IDRol = usuario.IDRol;

                    _context.Usuarios.Update(usuarioExistente);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var rolesList = _context.Roles.ToList();
                    ViewBag.RolesList = new SelectList(rolesList, "IDRol", "NombreRol");
                    return View(usuario);
                }
            }
            catch
            {
                var rolesList = _context.Roles.ToList();
                ViewBag.RolesList = new SelectList(rolesList, "IDRol", "NombreRol");
                return View(usuario);
            }
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
            catch
            {
                return View();
            }
        }
    }
    
}