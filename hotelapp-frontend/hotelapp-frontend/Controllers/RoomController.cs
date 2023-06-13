using Microsoft.AspNetCore.Mvc;

namespace hotelapp_frontend.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
