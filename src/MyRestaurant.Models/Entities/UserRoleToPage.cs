using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    public class UserRoleToPage:BaseModel
    {
        [ForeignKey("Page")]
        public long PageId { get; set; }
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public virtual Page Page { get; set; }
        //public virtual Role Role { get; set; }
    }
}
