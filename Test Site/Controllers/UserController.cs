using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Site.Controllers
{
    public class UserController : Controller
    {
        public IActionResult ViewProfile()
        {
            return View();
        }
    }
}
