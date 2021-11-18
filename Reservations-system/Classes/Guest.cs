using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    //ændre navn
    public class Guest : Client
    {
        //stuff
        public Guest(string name, string phoneNumber, string mail, string address, ContactPerson contactPerson) :
                base(name, phoneNumber, mail, address, contactPerson)
        {
        }

        public Guest()
        {
        }
    }
}