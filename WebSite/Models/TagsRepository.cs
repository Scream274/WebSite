using WebSite.Entities;

namespace WebSite.Models
{
    public class TagsRepository
    {
        private readonly PortfolioDBContext dBContext;

        public TagsRepository(PortfolioDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        internal List<Tag> GetAllTags()
        {
            return dBContext.Tags.OrderBy(o => o.Id).ToList();
        }

        internal List<Tag> GetTagsByPostId(int postId)
        {
            return (from pT in dBContext.PostTags
                    join t in dBContext.Tags on pT.TagId equals t.Id
                    where pT.PostId == postId
                    select t).ToList();
        }
    }
}
