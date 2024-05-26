using Microsoft.AspNetCore.Mvc;

namespace Test_Site.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
