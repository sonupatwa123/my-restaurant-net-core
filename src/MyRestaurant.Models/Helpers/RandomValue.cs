using System;
using System.Linq;

namespace MyRestaurant.Models.Helpers
{
    public static class RandomValue
    {
        public static int RandomNumber(int count)
        {
            Random r = new Random();
            int rInt = r.Next(0, 100); //for ints
            int range = count;
            int randomNumber = r.Next() * range;
            return randomNumber;

        }
        public static string RandomString(int count)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, count)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
