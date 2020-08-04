using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyRestaurant.Model.Entities
{
   public class Menu:BaseModel
    {
        [MaxLength(512)]
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }        
        public string MenuLogo { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }        
        [ForeignKey("MenuCategory")]
        public long MenuCategoryId { get; set; }
        [ForeignKey("Cuisine")]
        public long? CuisineId { get; set; }
        [NotMapped]
        public string Guid { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set;   }
        public virtual Cuisine Cuisine { get; set; }
    }
}
