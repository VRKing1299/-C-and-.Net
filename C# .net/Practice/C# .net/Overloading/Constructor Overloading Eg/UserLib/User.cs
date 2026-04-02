using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLib
{
    public class User
    {
        public string userName;
        public string email;
        public double phoneNo;
        private string Password { get; set; }

        public User ( string userName, string password)
        {
            this.userName = userName;
            Password = password;
        }

        public User(string userName, double phno, string password)
        {
            this.userName = userName;
            phoneNo = phno;
            Password = password;
        }

        public User( double phno, string password)
        {
            phoneNo = phno;
            Password = password;
        }
    }
}
