using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public abstract class Guest
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string PhoneNumber { get; set; }


        public string Mail { get; set; }


        public string Address { get; set; }


        public string AccountNumber { get; set; }


        public string RegistrationNumber { get; set; }


        public bool IsOver18 { get; set; }

    }
}
