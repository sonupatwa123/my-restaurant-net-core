using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurant.Model.Entities
{
    public class Country : BaseModel
    {
        [MaxLength(512)]

        public string Name { get; set; }
        [MaxLength(256)]
        
        public string Continental { get; set; }
        [MaxLength(25)]
        public string CountryCode { get; set; }
        public int PhoneCode { get; set; }
        [JsonIgnore]
        public virtual ICollection<State> States { get; set; }
        [JsonIgnore]
        public virtual ICollection<Address> Addresses { get; set; }
       
    }
}
