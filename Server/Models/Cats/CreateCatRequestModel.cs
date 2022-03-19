using System.ComponentModel.DataAnnotations;

namespace  Server.Models.Cats

{

    using static Data.Validation.Cat;
    public class CreateCatRequestModel
    {
         [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description {set;get;}


        [Required]
        public string ImageUrl {set;get;}
 
    }
}