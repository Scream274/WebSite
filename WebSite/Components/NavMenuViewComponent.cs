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
            List<Navigate> nav = (List<Navigate>)navigationRepository.GetNavigate().ToList();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                nav.Add(new Navigate() { Title="Logout", Href = "/Account/Logout", Order = nav.Count - 1 });
            }
            else
            {
                nav.Add(new Navigate() { Title = "Login", Href = "/Account/Login", Order = nav.Count - 1 });
                nav.Add(new Navigate() { Title = "Register", Href = "/Account/Register", Order = nav.Count - 1 });
            }

            return View("NavMenu", nav);
        }
    }
}