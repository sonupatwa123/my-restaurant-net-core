
namespace MyRestaurant.Model.Entities
{
   public class RestaurantTiming:BaseModel
    {
        public long RestaurantId { get; set; }
        public int DayFrom { get; set; }
        public int DayTo { get; set; }
        public string OpenFrom { get; set; }
        public string OpenTo { get; set; } 
        public virtual Restaurant Restaurant { get; set; }
    }
}
