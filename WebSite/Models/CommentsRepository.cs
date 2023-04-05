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

        internal List<Comment> GetCommentsThree(int postId)
        {
            var threeRoot = dBContext.Comments.Where(c => c.PostId == postId && c.IsValid && c.ParentId == null).OrderBy(c => c.DateOfCreation).ToList();
            var childsElements = dBContext.Comments.Where(c => c.PostId == postId && c.IsValid && c.ParentId != null).OrderBy(c => c.DateOfCreation).ToList();

            foreach (var rootEl in threeRoot)
            {
                rootEl.Childs = new List<Comment>();
                foreach(var childEl in childsElements)
                {
                    if(childEl.ParentId == rootEl.Id)
                    {
                        rootEl.Childs.Add(childEl);
                    }
                }
            }
            return threeRoot.ToList();
        }
    }
}
