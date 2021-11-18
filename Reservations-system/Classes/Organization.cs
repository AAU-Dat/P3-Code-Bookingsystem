using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class Organization
    {
        private string _phoneNumber;
        private string _mail;

        public string Phonenumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }


        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

    }
}
