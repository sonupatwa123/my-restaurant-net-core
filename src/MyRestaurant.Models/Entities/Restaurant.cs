using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    public class Restaurant : BaseModel
    {
        [MaxLength(512)]
        [Required]
        public string RestaurantName { get; set; }
        [MaxLength(24)]
        [Required]
        public string ContactNumber { get; set; }
        [ForeignKey("Address")]
        public long AddressId { get; set; }
        [MaxLength(512)]
        public string Logo { get; set; }
        [MaxLength(512)]
        public string HeaderImage { get; set; }
       // [ForeignKey("User")]
        public string AspNetUserId { get; set; }
        [MaxLength(20)]
        public string RestaurantCode { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        [MaxLength(1024)]
        public string AboutCookingQuality { get; set; }
        [MaxLength(1024)]
        public string AboutFoodQuality { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<DeliveryArea> DeliveryAreas { get; set; }
        //public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<DeliveryFees> DeliveryFees { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<RestaurantTiming> RestaurantTimings { get; set; }
        public virtual ICollection<RestaurantGallery> RestaurantGalleries { get; set; }
    }
}
