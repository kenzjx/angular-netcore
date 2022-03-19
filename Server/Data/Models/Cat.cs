using System.ComponentModel.DataAnnotations;

namespace Server.Data.Models
{
    using static Validation.Cat;
    public class Cat
    {
        public int Id {set;get;}

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description {set;get;}


        [Required]
        public string ImageUrl {set;get;}

        [Required]
        public string UserId {set;get;}

        public User User {set;get;}
    }
}