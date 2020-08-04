using System.ComponentModel.DataAnnotations.Schema;
using MyRestaurant.Model.Entities;

namespace MyRestaurant.Model.Models
{
    [NotMapped]
    public class UserDto : User
    {
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
                {
                    return FirstName + " " + LastName;
                }
                return string.Empty;
            }
        }
    }
}
