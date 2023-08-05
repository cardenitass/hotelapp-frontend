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
        public async Task<IActionResult> Detalle(int? id)
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
    }
}
