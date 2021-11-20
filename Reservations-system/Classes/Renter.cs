using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    
    public abstract class Renter
    {
        private string _name;
        private string _phoneNumber;
        private string _mail;
        private string _address;
        private ContactPerson _contactPerson; //Håndter korrekt


        protected Renter(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Address = address;
            ContactPerson = contactPerson;
        }

        protected Renter()
        {
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public ContactPerson ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
        }
    }
}
