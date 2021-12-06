using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class ContactPerson : Guest
    {
       
        public ContactPerson(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson, string accountNumber) : base(name, phoneNumber, mail, address, contactPerson, accountNumber)
        {
        }

        public ContactPerson()
        {
        }
    }
}
