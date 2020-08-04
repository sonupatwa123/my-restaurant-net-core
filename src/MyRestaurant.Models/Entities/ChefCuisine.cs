using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Entities
{
   public class ChefCuisine:BaseModel
    {
        [ForeignKey("RestaurantChef")]
        public long RestaurantChefId { get; set; }
        [ForeignKey("Cuisine")]
        public long CuisineId { get; set; }
        public RestaurantChef RestaurantChef { get; set; }
        public Cuisine Cuisine { get; set; }
    }
}
