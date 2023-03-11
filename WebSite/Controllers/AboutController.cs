using Microsoft.AspNetCore.Mvc;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ViewResult GetGuestMessage(GuestMessage guestMessage)
        {
            if (ModelState.IsValid)
            {
                MessagesRepository.AddGuestMessage(guestMessage);
                return View("Thanks", guestMessage);
            }
            else
            {
                return View("ContactUs");
            }
        }
    }
}
