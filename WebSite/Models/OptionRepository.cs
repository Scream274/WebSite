using WebSite.Entities;

namespace WebSite.Models
{
    public class OptionRepository
    {
        private readonly PortfolioDBContext portfolioDB;

        public OptionRepository(PortfolioDBContext portfolioDB)
        {
            this.portfolioDB = portfolioDB;
        }

        public IQueryable<Option> GetOptions()
        {
            return portfolioDB.Options.OrderBy(o => o.Id);
        }

        public List<Option> GetOptionsByRelation(string relation)
        {
            return portfolioDB.Options.Where(o => o.Relation.Contains(relation)).OrderBy(o => o.Order).ToList();
        }
    }
}
