using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MyRestaurant.Model.Entities
{
    public class MenuItem:BaseModel
    {
        [ForeignKey("Menu")]
        public long MenuId { get; set; }
        [MaxLength(256)]
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public float ItemPerUnitPrice { get; set; }
        [ForeignKey("DeliveryType")]
        public long DeliveryTypeId { get; set; }
        [MaxLength(512)]
        public string Logo { get; set; }
        [NotMapped]
        public string Guid { get; set; }
        [NotMapped]
        public string MenuGuid { get; set; }
        [JsonIgnore]
        public virtual DeliveryType DeliveryType { get; set; }
        [JsonIgnore]
        public virtual Menu Menu { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<MenuItemGallery> MenuItemGalleries { get; set; }

    }
}
