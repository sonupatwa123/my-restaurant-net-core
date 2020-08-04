using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Model.Entities
{
   public class MenuCategory:BaseModel
    {
        [MaxLength(256)]
        public string Name { get; set; }
        public bool IsGlobal { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
