using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class Order:BaseModel
    {
        public long UserId { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }
        [ForeignKey("DeliveryType")]
        public long DeliveryTypeId { get; set; }
        public long InvoiceId { get; set; }

        public bool IsPaid { get; set; }
        [ForeignKey("PaidMethod")]
        public long PaidMethodId { get; set; }
        public bool IsDelivered { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }

        public virtual PaidMethod PaidMethod { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual User User { get; set; }
        



    }
}
