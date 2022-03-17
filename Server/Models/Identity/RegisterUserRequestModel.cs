using System.ComponentModel.DataAnnotations;

namespace Server.Models.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
}