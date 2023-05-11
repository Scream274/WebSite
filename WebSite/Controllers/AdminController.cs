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
            }
            else
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
            if (avatarFile != null && avatarFile.FileName != "")
            {
                long imgSize = avatarFile.Length;
                string ext = System.IO.Path.GetExtension(avatarFile.FileName).ToLower();

                if (imgSize > 800000)
                {
                    return View("OperationError", new ErrorViewModel() { ErrorMessage = "The file size is too large. It should be no more than 800 KB." });
                }

                if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".jpeg" || ext == ".jfif" || ext == ".webp")
                {
                    string path = "/admin/img/avatars/";

                    var userInfo = _userInfoRepository.getUserInfoByEmail(User.Identity.Name);

                    string absFilePath = _appEnvironment.WebRootPath + path + userInfo.User.Login + "_" + userInfo.User.Id + ext;
                    using (var fileStream = new FileStream(absFilePath, FileMode.Create))
                    {
                        avatarFile.CopyTo(fileStream);
                        userInfo.Avatar = path + userInfo.User.Login + "_" + userInfo.User.Id + ext;
                        _dBContext.SaveChanges();

                        return RedirectToAction("MyProfile", "Admin");
                    }
                }
                else
                {
                    return View("OperationError", new ErrorViewModel() { ErrorMessage = "Unknown file extension." });
                }
            }
            else
            {
                return View("OperationError", new ErrorViewModel() { ErrorMessage = "Unable to access the file." });
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllWorks()
        {
            WorkRepository workRepository = new WorkRepository(_dBContext);
            var works = workRepository.GetAllWorks();
            return View("AllWorks", works);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteWork(int id)
        {
            var workToDelete = _dBContext.Works.Find(id);

            if (workToDelete == null)
            {
                return NotFound();
            }

            _dBContext.Works.Remove(workToDelete);
            _dBContext.SaveChanges();

            string absFileToRemovePath = _appEnvironment.WebRootPath + workToDelete.ImgSrc;
            System.IO.File.Delete(absFileToRemovePath);

            return RedirectToAction(nameof(GetAllWorks));
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddNewWOrk()
        {
            return View("AddNewWork");
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditWork(int id)
        {
            Work work = _dBContext.Works.Find(id);

            if (work != null)
            {
                return View(work);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddNewWork(Work work, IFormFile ImgSrc)
        {
            if (ModelState.IsValid)
            {
                _dBContext.Works.Add(work);
                _dBContext.SaveChanges();

                if (ImgSrc != null && ImgSrc.Length > 0)
                {
                    string fileName = $"{work.Slug}{Path.GetExtension(ImgSrc.FileName)}";

                    string path = Path.Combine(_appEnvironment.WebRootPath, "assets", "img", "works", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        ImgSrc.CopyTo(stream);
                    }

                    work.ImgSrc = $"/assets/img/works/{fileName}";
                    work.BigImgSrc = work.ImgSrc;
                    work.ImgAlt = work.Slug;
                    _dBContext.SaveChanges();
                }

                return RedirectToAction(nameof(GetAllWorks));
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditWork(Work work)
        {
            if (ModelState.IsValid)
            {
                _dBContext.Works.Update(work);
                _dBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(work);
            }
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAllPosts()
        {
            PostsRepository postsRepository = new PostsRepository(_dBContext);
            var posts = postsRepository.GetPosts();
            return View("AllPosts", posts);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeletePost(int id)
        {
            var item = _dBContext.Posts.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _dBContext.Posts.Remove(item);
            _dBContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditPost(int id)
        {
            Post post = _dBContext.Posts.Find(id);

            if (post != null)
            {
                return View(post);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                _dBContext.Posts.Update(post);
                _dBContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(post);
            }
        }
    }
}