using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Model.Entities
{
   public class PaidMethod:BaseModel
    {
        [MaxLength(512)]
        public string PadiMethodName { get; set; }
        [MaxLength(512)]
        public string Logo { get; set; }
        public virtual ICollection<Order> Orders{ get; set; }

    }
}
