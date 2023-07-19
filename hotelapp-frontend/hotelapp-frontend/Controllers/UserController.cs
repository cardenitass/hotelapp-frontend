using Microsoft.AspNetCore.Mvc;

namespace hotelapp_frontend.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
