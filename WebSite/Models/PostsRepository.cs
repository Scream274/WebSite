using WebSite.Entities;

namespace WebSite.Models
{
    public class PostsRepository
    {
        private readonly PortfolioDBContext _dbContext;

        public PostsRepository(PortfolioDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal IQueryable<Post> GetPosts()
        {
            return _dbContext.Posts.Where(p => p.PostStatus == Status.CRERATED).OrderBy(p => p.CreatedDate);
        }

        internal IQueryable<Post> GetPostsByCategory(string categorySlug)
        {
            //return _sportClubDB.Posts.Where(p => p.Status == Status.PUBLISHED).OrderBy(p => p.DateOfPublished);
            return (from p in _dbContext.Posts join c in _dbContext.Categories on p.CategoryId equals c.Id where p.PostStatus == Status.PUBLISHED && c.Slug == categorySlug select p);
        }

        internal IQueryable<Post> GetPostsByTags(string tagSlug)
        {
            return (from p in _dbContext.Posts
                    join pT in _dbContext.PostTags on p.Id equals pT.PostId
                    join t in _dbContext.Tags on pT.TagId equals t.Id
                    where p.PostStatus == Status.PUBLISHED && t.Name == tagSlug
                    select p);
        }

        internal Post GetOnePostBySlug(string slug)
        {
            return _dbContext.Posts.FirstOrDefault(p => p.Slug.ToUpper().Equals(slug.ToUpper()) && p.PostStatus == Status.PUBLISHED);
        }
    }
}