using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAdemo.Utils
{
    public class Utils
    {

        private static readonly Random Random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}