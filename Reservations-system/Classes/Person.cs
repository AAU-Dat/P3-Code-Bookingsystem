using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public abstract class Person
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _mail;
        private string _address;

        protected Person(string firstName, string lastName, string phoneNumber, string mail, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Address = address;
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
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
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
