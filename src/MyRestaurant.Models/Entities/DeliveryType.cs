using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Model.Entities
{
    public class DeliveryType:BaseModel
    {
        [MaxLength(128)]
        public string TypeName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }

    }
}
