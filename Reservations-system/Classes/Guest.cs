using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public abstract class Guest
    {
        public Guest()
        {

        }
        public Guest(string firstName, string lastName, string phoneNumber, string mail,
                        string address, string accountNumber, string registrationNumber, bool isOver18)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Mail = mail;
            Address = address;
            AccountNumber = accountNumber;
            RegistrationNumber = registrationNumber;
            IsOver18 = isOver18;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string PhoneNumber { get; set; }


        public string Mail { get; set; }


        public string Address { get; set; }


        public string AccountNumber { get; set; }


        public string RegistrationNumber { get; set; }


        public bool IsOver18 { get; set; }

        public string GuestFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
