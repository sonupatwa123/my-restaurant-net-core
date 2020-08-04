using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Entities
{
  public  class RestaurantGallery:BaseModel
    {
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }
        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        public Restaurant Restaurant { get; set; }
        public Gallery Gallery { get; set; }

    }
}
