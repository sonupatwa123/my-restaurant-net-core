using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class Feedback:BaseModel
    {
        [ForeignKey("User")]

        public long UserId { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }
        public string Feedbacks { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual User User { get; set; }
    }
}
