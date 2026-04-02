using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Admin
    {
        public int id;
        public string name;
        public User user;

        public Admin(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Admin (User user)
        {
            this.id = user.id;
            this.name = user.name;
        }

        public void searchUser(User user)
        {
            this.user = user;
        }

    }


    public class User
    {
        public int id;
        public string name;

        public User(int id , string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
