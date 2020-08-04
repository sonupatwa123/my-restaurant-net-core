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
    public class ChefCuisineDto : ChefCuisine
    {
        public string CuisineName
        {
            get
            {
                if (base.Cuisine != null)
                {
                    return base.Cuisine.Name;
                }
                return string.Empty;
            }
        }
    }
}
