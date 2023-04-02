using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Entities;

namespace WebSite.ViewModels
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories{ get; set; }
    }
}
