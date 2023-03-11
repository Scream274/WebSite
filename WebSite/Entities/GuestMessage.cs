using System.ComponentModel.DataAnnotations;

namespace WebSite.Entities
{
    public class GuestMessage
    {
        [Required(ErrorMessage = "Name cant be blank.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cant be blank.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email cant be blank.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject cant be blank.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message cant be blank.")]
        public string Message { get; set; }
    }
}