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

        //регистрация нового пользователя 
        public User(string FullName, string Email, string password, int RentBike, bool newPswTrue = false)
        //newPswTrue = true если пароль введен в поле регистрации
        //newPswTrue = false если пароль взят из json (hash уже есть)
        {
            this.FullName = FullName;
            this.Email = Email;
            this.BikeTaken = RentBike;
            if (newPswTrue)
            {
                this.Password = GetHash(password);
                newPswTrue = false;
                Console.WriteLine("this.Password0=" + this.Password);
            }
            else
            {
                this.Password = password;
            }

        }
        //хэширование
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(
               password));
            return Convert.ToBase64String(hash);
        }

    }
}
