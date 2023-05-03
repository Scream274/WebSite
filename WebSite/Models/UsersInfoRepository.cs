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

        internal bool ChangeUserInfo(string email, string login, string name, string surname, string phoneNumber, string address, string info)
        {

            var user = dBContext.Users.First(u => u.Email == email);
            var userInfo = dBContext.UserInfos.First(uI => uI.UserId == user.Id);

            user.Login = login;
            user.Email = email;
            userInfo.Name = name;
            userInfo.Surname = surname;
            userInfo.PhoneNumber = "+38" + phoneNumber;
            userInfo.Address = address;
            userInfo.Info = info;

            return dBContext.SaveChanges() == 1;
        }
    }
}