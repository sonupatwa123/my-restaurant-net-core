using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class MenuDto:Menu
    {
        public MenuDto() {
            MenuItems = new List<MenuItemDto>();
        }
        public new List<MenuItemDto> MenuItems { get; set; }
        public string OtherCategory { get; set; }
         
    }
}
