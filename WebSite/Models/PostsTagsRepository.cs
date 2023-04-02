using WebSite.Entities;

namespace WebSite.Models
{
    public class PostsTagsRepository
    {
        private readonly PortfolioDBContext _dbContext;

        public PostsTagsRepository(PortfolioDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
