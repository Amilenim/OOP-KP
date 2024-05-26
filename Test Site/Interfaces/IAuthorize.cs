using Microsoft.AspNetCore.Mvc;

namespace Test_Site.Interfaces
{
    public interface IAuthorize
    {
        public IActionResult Register();
        public IActionResult Login(string returnUrl = null);
        public Task<IActionResult> Logout();
    }
}
