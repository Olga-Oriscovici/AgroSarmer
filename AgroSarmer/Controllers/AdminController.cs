using Microsoft.AspNetCore.Mvc;

namespace AgroSarmer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
