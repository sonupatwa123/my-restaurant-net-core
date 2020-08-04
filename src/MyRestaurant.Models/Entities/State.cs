using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class State:BaseModel
    {
        [ForeignKey("Country")]
        public long CountryId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public virtual Country Country { get; set; }
        [JsonIgnore]

        public virtual ICollection<City> Cities { get; set; }
        [JsonIgnore]

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
