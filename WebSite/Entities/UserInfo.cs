using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Entities
{
    public class UserInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should not be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname should not be empty!")]
        public string Surname { get; set; }

        public string Avatar { get; set; } = "/admin/img/avatars/avatar.jpg";

        [Required(ErrorMessage = "Phone Number should not be empty!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address should not be empty!")]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Info should not be empty!")]
        [DataType(DataType.Text)]
        public string Info { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}