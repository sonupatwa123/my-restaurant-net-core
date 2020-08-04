using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
   public class Offer:BaseModel
    {
        [MaxLength(256)]
        [Required]
        public string OfferName { get; set;}
        [MaxLength(1024)]
        public string OfferDescription { get; set; }
        [Required]
        public float OfferPrice { get; set; }
        public int MaxOrder { get; set; }
        public string OfferImage { get; set; }
        [ForeignKey("Restaurant")]
        [Required]
        public long RestaurantId { get; set; }
        public virtual  Restaurant Restaurant { get; set; }
        [Column(TypeName ="date")]
        public DateTime? OfferStartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ? OfferEndDate { get; set; }

        public virtual ICollection<OfferItem> OfferItems { get; set; }

    }
}
