using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class ContactUs:BaseModel
    {
        [ForeignKey("User")]
        public long? UserId { get; set; }
        [MaxLength(256)]
        public string EmailId { get; set; }
        [MaxLength(512)]
        public string FirstName { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        public string Query { get; set; }
        public virtual User User { get; set; }

    }
}
