using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Login cant be empty")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Email cant be empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cant be empty")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [ValidateNever]
        public DateTime DateRegister { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
