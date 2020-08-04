using System;
using System.Collections.Generic;
using System.Text;

namespace MyRestaurant.Models.Helpers
{
   public class TrimAttribute : Attribute
    {
        public TrimAttribute()
        {

        }
        public TrimAttribute(string value)
        {
            value = value.Trim();
        }
    }
}
