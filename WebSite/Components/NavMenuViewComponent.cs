using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Components
{
    public class NavMenu : ViewComponent
    {
        private NavigationRepository navigationRepository;

        public NavMenu()
        {
            navigationRepository = new NavigationRepository(new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>()));
        }

        public IViewComponentResult Invoke()
        {
            return View("NavMenu", navigationRepository.GetNavigate());
        }
    }
}