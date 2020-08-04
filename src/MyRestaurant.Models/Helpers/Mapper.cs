using System;
using System.Linq;

namespace MyRestaurant.Models.Helpers
{
    public static class Mapper<Tin, Tout> where Tin : class where Tout : class
    {
        public static Tout Map(Tin obj1, Tout obj2)
        {
            var type1 = obj1.GetType();
            var type2 = obj2.GetType();

            foreach (var p1 in type1.GetProperties())
            {
                foreach (var p2 in type2.GetProperties())
                {
                    if (p1.Name == p2.Name && p1.GetType() == p2.GetType())
                    {
                        p2.SetValue(obj2, p1.GetValue(obj1));
                    }
                }
            }
            return obj2;
        }
        public static Tout Map(Tin obj1, Tout obj2, string[] ignore)
        {
            var type1 = obj1.GetType();
            var type2 = obj2.GetType();

            foreach (var p1 in type1.GetProperties())
            {
                if (!ignore.Contains(p1.Name))
                {
                    foreach (var p2 in type2.GetProperties())
                    {
                        if (p1.Name == p2.Name && p1.GetType() == p2.GetType())
                        {
                            p2.SetValue(obj2, p1.GetValue(obj1));
                        }
                    }
                }
            }
            return obj2;
        }
    }
}
