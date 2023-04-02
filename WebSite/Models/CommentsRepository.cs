using WebSite.Entities;

namespace WebSite.Models
{
    public class CommentsRepository
    {
        private readonly PortfolioDBContext dBContext;

        public CommentsRepository(PortfolioDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
    }
}
