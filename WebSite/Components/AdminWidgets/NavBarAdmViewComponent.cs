using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Components.AdminWidgets
{
    public class NavBarAdmViewComponent : ViewComponent
    {

        private UsersInfoRepository _userInfoRepository;

        public NavBarAdmViewComponent()
        {
            var dbContext = new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>());
            _userInfoRepository = new UsersInfoRepository(dbContext);
        }
        public IViewComponentResult Invoke()
        {
            return View("NavBarAdm", _userInfoRepository.getUserInfoByEmail(HttpContext.User.Identity.Name));
        }
    }
}