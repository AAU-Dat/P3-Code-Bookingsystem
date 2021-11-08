using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class User
    {
        private string _userName;
        private string _password;
        private string _email;

        public User(string userName, string password, string email)
        {
            Email = email;
            Password = password;
            UserName = userName;
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }


    }
}
