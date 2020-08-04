namespace MyRestaurant.Model.Entities
{
    public class AddressBook : BaseModel
    {
        public long UserId { get; set; }
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
    }
}
