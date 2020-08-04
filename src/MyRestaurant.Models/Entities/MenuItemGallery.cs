using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Entities
{
    public class MenuItemGallery : BaseModel
    {
        [ForeignKey("MenuItem")]
        public long MenuItemId {get;set;}
        [ForeignKey("Gallery")]
        public long GalleryId { get; set; }
        public MenuItem MenuItem { get; set; }
        public Gallery Gallery { get; set; }

    }
}
