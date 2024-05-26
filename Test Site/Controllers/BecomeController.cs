using Microsoft.AspNetCore.Mvc;

namespace Test_Site.Controllers
{
    public class BecomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
