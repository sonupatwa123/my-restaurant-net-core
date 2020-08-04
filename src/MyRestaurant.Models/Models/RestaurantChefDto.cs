using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
  public  class RestaurantChefDto:RestaurantChef
    {
        public new List<ChefCuisineDto> ChefCuisines { get; set; }
        public string RestaurantName
        {
            get
            {
                if (base.Restaurant != null)
                {
                    return Restaurant.RestaurantName;
                }
                return string.Empty;
            }
        }
    }
}
