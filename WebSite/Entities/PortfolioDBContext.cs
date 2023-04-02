using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace WebSite.Entities
{

    public class PortfolioDBContext : DbContext
    {
        public DbSet<Option> Options { get; set; }
        public DbSet<Navigate> Navigations { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public PortfolioDBContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=My_portfolio;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Option>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Work>().HasIndex(w => w.Slug).IsUnique();
            modelBuilder.Entity<Post>().HasIndex(p => p.Slug).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Slug).IsUnique();

            Option[] options = new Option[]
            {
                new Option(){Id = 1, Name = "Title", Value="My portfolio", Relation = ""},
                new Option(){Id = 2, Name = "Description", Value="My portfolio description", Relation = ""},
                new Option(){Id = 3, Name = "Logo", Value="/img/logo.png", Relation = ""},
                new Option(){Id = 4, Name = "Email", Value="mortfolio@gmail.com", Relation = ""},
                new Option(){Id = 5, Name = "Facebook", Value="https://www.facebook.com/", Key = "bi bi-facebook", Relation = "social_links", Order = 1},
                new Option(){Id = 6, Name = "Twitter", Value="https://twitter.com/", Key = "bi bi-twitter", Relation = "social_links", Order = 2},
                new Option(){Id = 7, Name = "Instagram", Value="https://www.instagram.com/", Key = "bi bi-instagram", Relation = "social_links", Order = 3},
                new Option(){Id = 8, Name = "Linkedin", Value="https://www.linkedin.com/", Key = "bi bi-linkedin", Relation = "social_links", Order = 4},
            };

            Navigate[] navigates = new Navigate[]
            {
                new Navigate(){ Id = 1, Title = "Home", Href= "/", Order = 1 },
                new Navigate(){ Id = 2, Title = "About", Href= "/about", Order = 2 },
                new Navigate(){ Id = 3, Title = "Me", Href= "/about/me", Order = 3 },
                new Navigate(){ Id = 4, Title = "Services", Href= "/services", Order = 4 },
                new Navigate(){ Id = 5, Title = "Works", Href= "/work", Order = 5 },
                new Navigate(){ Id = 6, Title = "Contact", Href= "/about/contactUs", Order = 6 },
                new Navigate(){ Id = 7, Title = "Blog", Href= "/blog", Order = 7 }
            };

            Category[] categories = new Category[]
            {
                new Category(){Id = 1, Name = "Web", Description = "All about web.", Slug = "Web", Order = 1},
                new Category(){Id = 2, Name = "Design", Description = "All about Design.", Slug = "Design", Order = 2},
                new Category(){Id = 3, Name = "Branding", Description = "All about Branding.", Slug = "Branding", Order = 3},
                new Category(){Id = 4, Name = "Photography", Description = "All about Photography.", Slug = "Photography", Order = 4}
            };

            modelBuilder.Entity<Category>().HasData(categories);

            Tag[] tags = new Tag[]
            {
                new Tag(){Id = 1, Name = "Web"},
                new Tag(){Id = 2, Name = "Design"},
                new Tag(){Id = 3, Name = "Branding"},
                new Tag(){Id = 4, Name = "Photography"}
            };

            modelBuilder.Entity<Tag>().HasData(tags);

            Post[] posts = new Post[]
            {
                new Post(){Id = 1, Title = "Post title - Web", Slug = "Web", Description = "Post about Web", ImgSrc = "/assets/img/posts/post.jpg", ImgAlt="Post image", Content = "Post content here...", AuthorImgSrc = "/assets/img/avatars/author.jpg" , Author = "Anatolii", CategoryId = 1},
                new Post(){Id = 2, Title = "Post title - Design", Slug = "Design", Description = "Post about Design", ImgSrc = "/assets/img/posts/post.jpg", ImgAlt="Post image", Content = "Post content here...", AuthorImgSrc = "/assets/img/avatars/author.jpg" , Author = "Anatolii", CategoryId = 2},
                new Post(){Id = 3, Title = "Post title - Branding", Slug = "Branding", Description = "Post about Branding", ImgSrc = "/assets/img/posts/post.jpg", ImgAlt="Post image", Content = "Post content here...", AuthorImgSrc = "/assets/img/avatars/author.jpg" , Author = "Anatolii", CategoryId = 3},
                new Post(){Id = 4, Title = "Post title - Photography", Slug = "Photography", Description = "Post about Photography", ImgSrc = "/assets/img/posts/post.jpg", ImgAlt="Post image", Content = "Post content here...", AuthorImgSrc = "/assets/img/avatars/author.jpg" , Author = "Anatolii", CategoryId = 4},
            };

            modelBuilder.Entity<Post>().HasData(posts);

            Comment[] comments = new Comment[]
            {
                new Comment(){Id = 1, Text = "Comment 1", Login = "Simple Login", Email = "login@gmail.com", PostId = 1},
                new Comment(){Id = 2, Text = "Test Comment 2", Login = "Super Login", Email = "super@gmail.com", PostId = 1},
                new Comment(){Id = 3, Text = "Sample comment 3", Login = "Almost Login", Email = "almost@gmail.com", PostId = 1},
                new Comment(){Id = 4, Text = "Comment just comment 4", Login = "Im Login", Email = "before@gmail.com", PostId = 1}
            };
            modelBuilder.Entity<Comment>().HasData(comments);

            PostTag[] postTags = new PostTag[]
            {
                new PostTag(){Id = 1, PostId = 1, TagId = 1},
                new PostTag(){Id = 2, PostId = 2, TagId = 2},
                new PostTag(){Id = 3, PostId = 3, TagId = 3},
                new PostTag(){Id = 4, PostId = 4, TagId = 4}
            };
            modelBuilder.Entity<PostTag>().HasData(postTags);

            Work[] works = new Work[]
            {
                new Work()
                {
                    Id = 1,
                    Title = "Boxed Water",
                    ImgSrc = "/assets/img/img_1.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Boxed Water",
                    Category = "Web",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Boxed_Water",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                },
                new Work()
                {
                    Id = 2,
                    Title = "Cocooil",
                    ImgSrc = "/assets/img/img_3.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Cocooil",
                    Category = "Branding",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Cocooil",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                },
                new Work()
                {
                    Id = 3,
                    Title = "Build Indoo",
                    ImgSrc = "/assets/img/img_2.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Build Indoo",
                    Category = "Photography",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Build_Indoo",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                },
                new Work()
                {
                    Id = 4,
                    Title = "Nike Shoe",
                    ImgSrc = "/assets/img/img_4.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Nike Shoe",
                    Category = "Design",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Nike_Shoe",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                },
                new Work()
                {
                    Id = 5,
                    Title = "Kitchen Sink",
                    ImgSrc = "/assets/img/img_5.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Kitchen Sink",
                    Category = "Design",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Kitchen_Sink",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                },
                new Work()
                {
                    Id = 6,
                    Title = "Amazon",
                    ImgSrc = "/assets/img/img_6.jpg",
                    BigImgSrc = "/assets/img/img_1_big.jpg",
                    ImgAlt = "Amazon",
                    Category = "Branding",
                    Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam necessitatibus incidunt ut officiis explicabo inventore.",
                    Slug = "Amazon",
                    Keywords = "Design, HTML5/CSS3, CMS, Logo",
                    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolores illo, id recusandae molestias\r\n                    illum unde pariatur, enim tempora."
                }
            };

            modelBuilder.Entity<Option>().HasData(options);
            modelBuilder.Entity<Navigate>().HasData(navigates);
            modelBuilder.Entity<Work>().HasData(works);
        }
    }
}