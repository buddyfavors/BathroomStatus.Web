using Microsoft.AspNetCore.Mvc;

namespace BathroomStatus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
