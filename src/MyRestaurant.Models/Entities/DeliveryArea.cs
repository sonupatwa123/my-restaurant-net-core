using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
namespace MyRestaurant.Model.Entities
{
   public class DeliveryArea:BaseModel
    {

        public float Longitude { get; set; }
        public float Latitude { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }

        public string Address { get; set; }
        [JsonIgnore]
        public virtual Restaurant Restaurant{ get; set; }
    }
}
