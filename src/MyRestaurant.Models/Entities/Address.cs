using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MyRestaurant.Model.Entities
{
    public class Address : BaseModel
    {
        [MaxLength(512)]
        [Required]
        public string AddressLine1 { get; set; }
        [MaxLength(512)]

        public string AddressLine2 { get; set; }
        [MaxLength(7)]
        [Required]
        [MinLength(6)]
        public string PostalCode { get; set; }
        [ForeignKey("Country")]
        [Required]
        public long CountryId { get; set; }
        [ForeignKey("State")]
        [Required]
        public long StateId { get; set; }
        [ForeignKey("City")]
        [Required]
        public long CityId { get; set; }
        
        public float? Longitude { get; set; }
       
        public float? Latitude { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}
