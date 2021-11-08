using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class AdminInfo
    {
        private string telephoneNumber;
        private string email;
        private string adress;

        public AdminInfo(string telephoneNumber, string email, string adress)
        {
            TelephoneNumber = telephoneNumber;
            Email = email;
            Adress = adress;
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }


    }
}
