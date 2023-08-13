using hotelapp_frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hotelapp_frontend.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HotelAppContext _context;

        public ReservationController(HotelAppContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habitacion.ToListAsync());
        }

        [HttpGet]

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservaciones.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Reservacion reservacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Reservaciones.Update(reservacion);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(reservacion);
                }
            }
            catch
            {
                return View(reservacion);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservaciones.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var reservacion = await _context.Reservaciones.FindAsync(id);
                if (reservacion == null)
                {
                    return NotFound();
                }

                _context.Reservaciones.Remove(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]

        public IActionResult ReservaHabitacion(int id)
        {
            var habitacion = _context.Habitacion.Find(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }


    }
}
