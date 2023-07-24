using hotelapp_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hotelapp_frontend.Controllers
{
    public class RoomController : Controller
    {
        private readonly HotelAppContext _context;
        public RoomController(HotelAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
              return View(await _context.Habitacion.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var tipoHabitacion = _context.TipoHabitacion.ToList();
            ViewBag.TipoHabitacion = tipoHabitacion;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Habitacion habitacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Habitacion.Add(habitacion);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(habitacion);
                }
            }
            catch
            {
                return View(habitacion);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            // Obtener la lista de tipos de habitación y agregarla al ViewBag
            var tiposHabitacion = _context.TipoHabitacion.ToList();
            ViewBag.TipoHabitacion = new SelectList(tiposHabitacion, "IDTipoHabitacion", "NombreTipoHabitacion");

            return View(habitacion);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Habitacion habitacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Actualizar la habitación en la base de datos
                    _context.Habitacion.Update(habitacion);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Si el modelo no es válido, recargar la lista de tipos de habitación y volver a la vista de edición con los mensajes de validación
                    var tiposHabitacion = _context.TipoHabitacion.ToList();
                    ViewBag.TipoHabitacion = new SelectList(tiposHabitacion, "IDTipoHabitacion", "NombreTipoHabitacion");
                    return View(habitacion);
                }
            }
            catch
            {
                // Si ocurre una excepción, recargar la lista de tipos de habitación y volver a la vista de edición con el modelo de habitación
                var tiposHabitacion = _context.TipoHabitacion.ToList();
                ViewBag.TipoHabitacion = new SelectList(tiposHabitacion, "IDTipoHabitacion", "NombreTipoHabitacion");
                return View(habitacion);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> Editar(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var habitacion = await _context.Habitacion.FindAsync(id);
        //    if (habitacion == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(habitacion);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Editar(Habitacion habitacion)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Habitacion.Update(habitacion);
        //            await _context.SaveChangesAsync();

        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            return View(habitacion);
        //        }

        //    }
        //    catch
        //    {
        //        return View(habitacion);
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Eliminar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var habitacion = await _context.Habitacion.FindAsync(id);
                if (habitacion == null)
                {
                    return NotFound();
                }

                _context.Habitacion.Remove(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var habitacion = await _context.Habitacion.FindAsync(id);
                if (habitacion == null)
                {
                    return NotFound();
                }

                return View(habitacion);
            }
            catch
            {
                return View();
            }
        }

    }
}
