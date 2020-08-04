using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Entities
{
   public class Gallery:BaseModel
    {        
        [MaxLength(256)]
        public string MIMEType { get; set; }        
        public string FileName { get; set; }
        public float FileSize { get; set; }
    }
}
