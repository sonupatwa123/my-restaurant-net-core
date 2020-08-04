using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]

    public class CityDto:City
    {
        public string StateName
        {
            get {
                if (base.State != null)
                {
                    return base.State.Name;
                }
                return string.Empty;
            }
        }
    }
}
