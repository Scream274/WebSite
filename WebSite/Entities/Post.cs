using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status? PostStatus { get; set; } = Status.CRERATED;
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public string? ImgSrc { get; set; }
        public string? ImgAlt { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public string? AuthorImgSrc { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        public Category? category { get; set; }
    }
}
