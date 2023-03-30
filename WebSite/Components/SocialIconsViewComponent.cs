using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Entities;
using WebSite.Models;

namespace WebSite.Components
{
    public class SocialIconsViewComponent: ViewComponent
    {
        private OptionRepository optionsRepo;

        public SocialIconsViewComponent()
        {
            optionsRepo = new OptionRepository(new PortfolioDBContext(new DbContextOptions<PortfolioDBContext>()));
        }

        public IViewComponentResult Invoke()
        {
            return View("SocialIcons", optionsRepo.GetOptionsByRelation("social_links"));
        }
    }
}