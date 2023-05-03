using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Entities;

namespace WebSite.Models
{
    public class UsersInfoRepository
    {
        private readonly PortfolioDBContext dBContext;

        public UsersInfoRepository(PortfolioDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public UserInfo getUserInfoByEmail(string email)
        {
            var user = dBContext.Users.First(u => u.Email == email);
            var userInfo = dBContext.UserInfos.First(uI => uI.UserId == user.Id);
            user.Role = dBContext.Roles.SingleOrDefault(r => r.Id == user.RoleId);
            userInfo.User = user;
            return userInfo;
        }
    }
}