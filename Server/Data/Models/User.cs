using Microsoft.AspNetCore.Identity;

namespace Server.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Cat> Cats {set;get;}
    }
}