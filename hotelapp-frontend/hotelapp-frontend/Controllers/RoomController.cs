using Microsoft.AspNetCore.Mvc;

namespace hotelapp_frontend.Controllers
{
    public class RoomController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RoomDetails()
        {
            return View();
        }


    }
}
