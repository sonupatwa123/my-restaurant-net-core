using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
  public class Page:BaseModel
    {
        [MaxLength(256)]
        public string Name { get; set; }     
        public string Url { get; set; }
        [MaxLength(128)]
        public string ControllerName { get; set; }
        [MaxLength(128)]
        public string ActionName { get; set; }
        [MaxLength(256)]
        public string IconClass { get; set; }
        [ForeignKey("Parent")]
        public long? ParentId { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        [JsonIgnore]
        public virtual Page Parent { get; set;}
        //public virtual ICollection<Role> Roles { get; set;}
    }
}
