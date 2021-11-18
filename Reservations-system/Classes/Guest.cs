using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class Guest : Client
    {
        private ContactPerson _contactPerson;

        public Guest(string firstName, string lastName, string phoneNumber, string mail, string address, bool isOver18,
                        ContactPerson contactPerson) : base(firstName, lastName, phoneNumber, mail, address)
        {
        }

        public ContactPerson ContactPerson
        {
            get { return _contactPerson; }
            set { _contactPerson = value; }
        }

    }
}
