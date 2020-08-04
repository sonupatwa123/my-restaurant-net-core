using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class OrderItem:BaseModel
    {
        [ForeignKey("Order")]

        public long OrderId { get; set; }
        [ForeignKey("MenuItem")]
        public long MenuItemId { get; set; }

        public virtual Order Order{ get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
