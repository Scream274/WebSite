using System.ComponentModel.DataAnnotations.Schema;

namespace WebSite.Entities
{
    public class PostTag
    {
        public int Id { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
    }
}
