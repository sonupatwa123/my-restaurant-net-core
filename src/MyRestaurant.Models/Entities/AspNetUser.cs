//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;


//namespace MyRestaurant.Model.Entities
//{
//    public class AspNetUsers
//    {
//        private string userName;
//        public string Id { get; set; }
//        [MaxLength(256)]
//        public string Email { get; set; }
//        [DefaultValue(false)]
//        public bool EmailConfirmed { get; set; }

//        public string PasswordHash { get; set; }

//        public string SecurityStamp { get; set; }
//        [MaxLength(12)]
//        public string PhoneNumber { get; set; }
//        [DefaultValue(false)]
//        public bool PhoneNumberConfirmed { get; set; }
//        [DefaultValue(false)]
//        public bool TwoFactorEnabled { get; set; }

//        public DateTime? LockoutEndDateUtc { get; set; }
//        [DefaultValue(false)]
//        public bool LockoutEnabled { get; set; }
//        [DefaultValue(5)]
//        public int AccessFailedCount { get; set; }

//        public string UserName
//        {
//            get
//            {
//                if (string.IsNullOrEmpty(Email))
//                {
//                    return Email;
//                }
//                return userName;
//            }
//            set
//            {
//                userName = value;
//            }
//        }

//        public virtual ICollection<AspNetUserRoles> Roles { get; set; }

//        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
//        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
//    }
//}
