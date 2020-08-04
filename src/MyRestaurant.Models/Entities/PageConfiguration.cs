

namespace MyRestaurant.Model.Entities
{
    public class PageConfiguration
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Search { get; set; }
        public string UserId { get; set; }
        public bool ShowDeleted { get; set; }


    }
}
