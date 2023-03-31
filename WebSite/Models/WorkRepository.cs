using WebSite.Entities;

namespace WebSite.Models
{
    public class WorkRepository
    {
        private readonly PortfolioDBContext _portfolioDB;

        public WorkRepository(PortfolioDBContext portfolioDB)
        {
            _portfolioDB = portfolioDB;
        }

        public IQueryable<Work> GetAllWorks()
        {
            return _portfolioDB.Works.OrderBy(w => w.Id);
        }

        public Work GetWorkBySlug(string slug)
        {
            return _portfolioDB.Works.First(o => o.Slug == slug);
        }
    }
}