using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public abstract class Client : Person
    {
        
        private string _accountNumber;
        private string _registrationNumber;

        protected Client(string firstName, string lastName, string phoneNumber, string mail, string address) : base(firstName, lastName, phoneNumber, mail, address)
        {

        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        public string RegistrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
        }

        public string AccNrAndRegNr()
        {
            return $"{AccountNumber} + {RegistrationNumber}";
        }

    }
}
