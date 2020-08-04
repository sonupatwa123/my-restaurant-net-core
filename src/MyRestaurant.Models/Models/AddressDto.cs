using MyRestaurant.Model.Entities;
using MyRestaurant.Model.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class AddressDto : Address
    {
        string countryname;
        string statename;
        string cityname;
        public string CountryName
        {
            get {
                if (Country != null)
                {
                    return Country.Name;
                }
                return countryname;
            }
            set
            {
                countryname = value;
            }
        }
        public string StateName { get {
                if (State != null)
                {
                    return State.Name;
                }
                return statename;
            }
            set {
                statename = value;
            }
        }
        public string CityName { get {
                if (City != null)
                {
                    return City.Name;
                }
                return cityname;
            }
            set { cityname = value; }
        }

        
    }
}
