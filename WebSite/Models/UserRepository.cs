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
            user.Role = dBContext.Roles.SingleOrDefault(r => r.Id == user.RoleId);
            return user;
        }
    }
}
