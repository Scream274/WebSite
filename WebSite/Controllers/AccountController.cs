using FirstWebApplication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        private static PortfolioDBContext _dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
        private UserRepository userRepository = new UserRepository(_dBContext);

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
        public IActionResult CheckUser(string Email, string Password)
        {
            User? user = userRepository.GetUserByEmail(Email);
            if (user != null && SecurePasswordHasher.Verify(Password, user.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),
                    new Claim(ClaimTypes.Country, "UA"),
                    new Claim("Login", user.Login)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Admin");
            }
            return View("UserNotFound");
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            user.RoleId = 3;

            if (userRepository.GetUserByEmail(user.Email) != null)
            {
                TempData["ErrorMessage"] = "This user is already registered";
                return RedirectToAction("Register", "Account");
            }

            user.Password = SecurePasswordHasher.Hash(user.Password);
            user.DateRegister = DateTime.Now;
            userRepository.Add(user);
            TempData["SuccessMessage"] = "You have successfully registered.";

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
