using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class Rating:BaseModel
    {
        [ForeignKey("Restaurant")]
        public long? RestaurantId { get; set; }
        [ForeignKey("User")]        
        public long UserId { get; set; }
        public byte Rate { get; set; }
        public string Comments { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }
        [ForeignKey("MenuItem")]
        public long? MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        
    }
}
