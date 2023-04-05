using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WebSite.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public string? Login { get; set; }

        public string? Email { get; set; }

        [DefaultValue("/assets/img/avatars/avatar.png")]
        public string? Avatar { get; set; } = "/assets/img/avatars/avatar.jpg";

        public bool IsValid { get; set; } = true;

        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        [ForeignKey("Comments")]
        public int? ParentId { get; set; }

        [ForeignKey("Posts")]
        public int PostId { get; set; }

        public ICollection<Comment> Childs { get; set; }
    }
}
