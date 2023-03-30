using Microsoft.EntityFrameworkCore;

namespace WebSite.Entities
{

    public class PortfolioDBContext : DbContext
    {
        public DbSet<Option> Options { get; set; }


        public PortfolioDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=My_portfolio;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Option[] options = new Option[]
            {
                new Option(){Id = 1, Name = "Title", Value="My portfolio", Relation = ""},
                new Option(){Id = 2, Name = "Description", Value="My portfolio description", Relation = ""},
                new Option(){Id = 3, Name = "Logo", Value="/img/logo.png", Relation = ""},
                new Option(){Id = 4, Name = "Email", Value="mortfolio@gmail.com", Relation = ""},
                new Option(){Id = 5, Name = "Facebook", Value="https://www.facebook.com/", Relation = "socail_links", Order = 1},
                new Option(){Id = 6, Name = "Twitter", Value="https://twitter.com/", Relation = "socail_links", Order = 2},
                new Option(){Id = 7, Name = "Instagram", Value="https://www.instagram.com/", Relation = "socail_links", Order = 3},
                new Option(){Id = 8, Name = "Linkedin", Value="https://www.linkedin.com/", Relation = "socail_links", Order = 4},
            };

            modelBuilder.Entity<Option>().HasData(options);
        }
    }
}
