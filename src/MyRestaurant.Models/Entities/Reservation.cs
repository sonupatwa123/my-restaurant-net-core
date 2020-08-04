using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class Reservation:BaseModel
    {
        [MaxLength(512)]
        public string FirstName { get; set; }
        [MaxLength(512)]
        public string LastName { get; set; }
        [MaxLength(512)]
        public string EmailId { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }
        public int TableNumber { get; set; }
        public int NumberOfMembers { get; set; }
        [MaxLength(1024)]
        public string Comment { get; set; }
        [ForeignKey("Restaurant")]
        public long RestaurantId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        public User User { get; set; }

        public Restaurant Restaurant { get; set; }
    }

}
