using System.Collections.Generic;

namespace MyRestaurant.Model.Models
{

    public class PageResultModel<T> where T : class
    {
        public PageResultModel()
        {
            Records = new List<T>();
        }

        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Records { get; set; }
        public int Showing { get; set; }
    }
}
