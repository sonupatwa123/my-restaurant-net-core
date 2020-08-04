using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class DeliveryFees:BaseModel
    {
        public int DistanceFrom { get; set; }
        public int DistanceTo { get; set; }
        public float Fees { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
