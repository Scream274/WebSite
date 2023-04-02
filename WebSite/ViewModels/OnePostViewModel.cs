using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Entities;

namespace WebSite.ViewModels
{
    public class OnePostViewModel
    {
        public Post Post { get; set; } = null;

        public List<Tag> Tags { get; set; } = new List<Tag>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
