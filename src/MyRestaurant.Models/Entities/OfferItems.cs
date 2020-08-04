using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{

  public  class OfferItem:BaseModel
    {
        [ForeignKey("Offer")]
        public long OfferId { get; set; }
        [ForeignKey("MenuItem")]
        public long MenuItemId { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual MenuItem MenuItem { get; set;}

    }
}
