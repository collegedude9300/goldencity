using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace GoldenCities.ClassModels
{
  
    public class User
    {
        
        public string EmailID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User()
        {
            
        }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
            this.EmailID = EmailID;
        }

        public bool CheckInformation()
        {
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
// password must include a capital letter and a number
