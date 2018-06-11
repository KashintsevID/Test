using Cycle.Info.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CardNumber { get; set; }
        public decimal Balance { get; set; }
        [JsonIgnore]
        public Bicycle Bicycle { get; set; }
        public int BikeTaken { get; set; }
        public DateTime BeginingOfRent { get; set; }
        
        //хэширование пароля
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(
               password));
            return Convert.ToBase64String(hash);
        }
    }
}
