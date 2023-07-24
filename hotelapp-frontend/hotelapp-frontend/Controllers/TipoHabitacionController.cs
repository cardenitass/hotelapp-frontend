using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotelapp_frontend.Models;

namespace hotelapp_frontend.Controllers
{
    public class TipoHabitacionController : Controller
    {
        private readonly HotelAppContext _context;

        public TipoHabitacionController(HotelAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoHabitacion.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoHabitacion tipoHabitacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TipoHabitacion.Add(tipoHabitacion);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(tipoHabitacion);
                }
            }
            catch
            {
                return View(tipoHabitacion);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(TipoHabitacion tipoHabitacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.TipoHabitacion.Update(tipoHabitacion);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(tipoHabitacion);
                }
            }
            catch
            {
                return View(tipoHabitacion);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
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

                var tipohabitacion = await _context.TipoHabitacion.FindAsync(id);
                if (tipohabitacion == null)
                {
                    return NotFound();
                }

                _context.TipoHabitacion.Remove(tipohabitacion);
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
