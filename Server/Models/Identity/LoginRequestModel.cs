using System.ComponentModel.DataAnnotations;

namespace Server.Models.Identity
{
    public class LoginRequestModel
    {
        [Required]
       
        public string UserName { set; get; }
        [Required]
       
        public string Password { set; get; }
    }
}