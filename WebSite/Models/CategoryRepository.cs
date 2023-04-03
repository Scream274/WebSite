using WebSite.Entities;

namespace WebSite.Models
{
    public class CategoryRepository
    {
        private readonly PortfolioDBContext _dbContext;

        public CategoryRepository(PortfolioDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories;
        }

    }
}
