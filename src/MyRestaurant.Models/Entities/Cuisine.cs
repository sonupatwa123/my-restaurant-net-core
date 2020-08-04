using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Model.Entities
{
   public class Cuisine: BaseModel
    {
        [MaxLength(512)]
        public string Name { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
