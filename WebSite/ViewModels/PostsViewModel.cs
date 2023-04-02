using WebSite.Entities;

namespace WebSite.ViewModels
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories{ get; set; }

        public string CategorySlug { get; set; } = null;
        public string TagSlug { get; set; } = null;
    }
}