using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    public class City:BaseModel
    {
        [ForeignKey("State")]
        public long StateId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public virtual State State { get; set; }
        [JsonIgnore]

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
