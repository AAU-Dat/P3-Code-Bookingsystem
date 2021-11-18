using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class ContactPerson : Person
    {
        public ContactPerson(string firstName, string lastName, string phoneNumber, string mail, string address) 
                                : base(firstName, lastName, phoneNumber, mail, address)
        {

        }
    }
}
