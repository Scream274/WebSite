using WebSite.Entities;

namespace WebSite.Models
{
    public class UserRepository
    {
        private readonly PortfolioDBContext dBContext;

        public UserRepository(PortfolioDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        internal User? GetUserByEmail(string email)
        {
            User user = dBContext.Users.SingleOrDefault(u => u.Email == email);
            if(user != null)
            {
                user.Role = dBContext.Roles.SingleOrDefault(r => r.Id == user.RoleId);
            }
            Console.WriteLine(user);
            return user;
        }

        internal void Add(User user)
        {
            dBContext.Users.Add(user);
            dBContext.SaveChanges();
        }
    }
}
