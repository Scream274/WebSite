using System.Security.Claims;
using FirstWebApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AdminController : Controller
    {
        private static PortfolioDBContext _dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());

        private UserRepository _userRepository = new UserRepository(_dBContext);
        private UsersInfoRepository _userInfoRepository = new UsersInfoRepository(_dBContext);
        private IWebHostEnvironment _appEnvironment;

        public AdminController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

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

        [Authorize]
        public IActionResult MyProfile()
        {
            return View("MyProfile", _userInfoRepository.getUserInfoByEmail(User.Identity.Name));
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChangeProfilePassword(string Password, string CPassword)
        {
            if (Password == CPassword)
            {
                Password = SecurePasswordHasher.Hash(Password);
                if (_userRepository.ChangePassword(User.Identity.Name, Password))
                {
                    return View("OperationSuccsess");
                }
            }
            return View("OperationError");
        }

        [HttpPost]
        [Authorize]
        public IActionResult ChangeProfileInfo(string Login, string Name, string Surname, string PhoneNumber, string Address, string Info)
        {
            if (_userInfoRepository.ChangeUserInfo(User.Identity.Name, Login, Name, Surname, PhoneNumber, Address, Info))
            {
                return View("OperationSuccsess");
            }
            return View("OperationError");
        }

        [HttpPost]
        [Authorize]
        public IActionResult UploadProfileAvatar(IFormFile avatarFile)
        {
            if (avatarFile != null)
            {
                string path = "/admin/img/avatars/" + avatarFile.FileName;
                string absFilePath = _appEnvironment.WebRootPath + path;

                using (var fileStream = new FileStream(absFilePath, FileMode.Create))
                {
                    avatarFile.CopyTo(fileStream);
                    return RedirectToAction("MyProfile", "Admin");
                }
            }
            else
            {
                return View("OperationError");
            }
        }
    }
}
