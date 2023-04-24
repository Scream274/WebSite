using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckUser()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult RegisterUser(string login, string email, string password, string rePassword)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
