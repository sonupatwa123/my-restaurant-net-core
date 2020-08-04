using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class RestaurantDto : Restaurant
    {
        public RestaurantDto()
        {
            Menus = new List<MenuDto>();
            DeliveryAreas = new List<DeliveryAreaDto>();
            DeliveryFees = new List<DeliveryFeesDto>();
        }
        public new List<MenuDto> Menus { get; set; }
        public new List<DeliveryAreaDto> DeliveryAreas { get; set; }

        public new AddressDto Address { get; set; }
        public new  List<DeliveryFeesDto> DeliveryFees { get; set; }
        public new List<GalleryDto> RestaurantGalleries { get; set;}
    }
}
