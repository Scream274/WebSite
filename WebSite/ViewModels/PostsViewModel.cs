using WebSite.Entities;

namespace WebSite.ViewModels
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories{ get; set; }

        public Post Post { get; set; } = null;

        public List<Tag> PostTags { get; set; } = new List<Tag>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public string CategorySlug { get; set; } = null;
        public string TagSlug { get; set; } = null;
        public string CategoryName { get; set; } = "All posts";
        public Comment Comment { get; set; }
    }
}