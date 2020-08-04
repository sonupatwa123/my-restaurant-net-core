using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Model.Entities
{
    public class RestaurantChef:BaseModel
    {
        public long RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AboutChef { get; set; }
        public string ProofType { get; set; }
        public string IdProof { get; set; }
        public string Image { get; set; }
        public short ChefRating { get; set; }
        public virtual ICollection<ChefCuisine> ChefCuisines { get; set; }        
        public virtual Restaurant Restaurant { get; set; }

    }
}
