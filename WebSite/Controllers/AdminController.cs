using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Role = User.FindFirst(u => u.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                return View("Main");
            } else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
