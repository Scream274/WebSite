using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private static PortfolioDBContext dBContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
        private OptionRepository optionRepository = new OptionRepository(dBContext);

        public HomeController(ILogger<HomeController> logger)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}