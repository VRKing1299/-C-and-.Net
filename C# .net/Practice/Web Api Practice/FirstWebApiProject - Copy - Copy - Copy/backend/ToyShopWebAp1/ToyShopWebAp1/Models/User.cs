using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToyShopWebAp1.Models
{
    //this is the users class used to represent the user
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}