using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class OfferDto : Offer
    {
        public OfferDto()
        {
            OfferItems = new List<OfferItemDto>();
        }
        public List<MenuItemDto> MenuItems { get; set; }
        public string RestaurantName
        {
            get {
                if (base.Restaurant != null)
                {
                    return Restaurant.RestaurantName;
                }
                return string.Empty;
            }
        }
        public new  List<OfferItemDto> OfferItems { get; set; }
    }
}
