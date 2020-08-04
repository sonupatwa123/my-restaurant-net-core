using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    public class User : BaseModel
    {       
        public string UserId { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string MiddleName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(512)]
        public string ProfileImage { get; set; }
        [MaxLength(256)]
        public string EmailAddress { get; set; }
        [ForeignKey("Address")]
        public long? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        //public virtual AspNetUsers AspNetUser { get; set; }
        public virtual ICollection<AddressBook> AddressBooks { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<ContactUs> ContactUs{ get; set; }



    }
}
