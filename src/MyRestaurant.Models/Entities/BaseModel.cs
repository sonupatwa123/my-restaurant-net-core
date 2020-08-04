using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyRestaurant.Model.Entities
{
    public abstract class BaseModel
    {
        DateTime createdDate;
        DateTime modifiedDate;
        
        public long Id { get; set; }
        [DefaultValue("(getdate())")]
        public DateTime CreatedDate
        {
            get;set;
        }
        [DefaultValue("(getdate())")]
        public DateTime UpdatedDate
        {
            get;set;
        }        
        public string CreatedById { get; set; }        
        public string UpdatedById { get; set; }        
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
