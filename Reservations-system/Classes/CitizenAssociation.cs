using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class CitizenAssociation
    {
        private string _phoneNumber;
        private string _mail;

        public string PhoneNumber
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
