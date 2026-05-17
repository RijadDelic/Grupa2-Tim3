using Microsoft.AspNetCore.Mvc;

namespace laptopi.etf1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
