using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class OfferItemDto : OfferItem
    {
        private string itemname;
        public string ItemName
        {
            get
            {
                if (MenuItem != null)
                {
                    return MenuItem.ItemName;
                }
                return itemname;
            }
            set {
                itemname = value;
            }
        }
    }
}
