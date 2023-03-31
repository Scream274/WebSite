using WebSite.Entities;

namespace WebSite.Models
{
    public class NavigationRepository
    {
        private readonly PortfolioDBContext portfolioDB;

        public NavigationRepository(PortfolioDBContext portfolioDB)
        {
            this.portfolioDB = portfolioDB;
        }

        public IEnumerable<Navigate> GetNavigate()
        {
            return portfolioDB.Navigations.OrderBy(n => n.Order).ToList();
        }
    }
}