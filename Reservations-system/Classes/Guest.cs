using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public abstract class Guest
    {

        public Guest(string firstname, string lastname, string phonenumber, string mail, string address, string acconutnumber,
            string reg, bool isover18, DateTime startDate, DateTime finishDate, bool cleaning, string otherInfo, int iD)
        {

            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Mail = mail;
            Address = address;
            AccountNumber = acconutnumber;
            RegistrationNumber = reg;
            IsOver18 = isover18;


            


            Reservation res = new Reservation(startDate, finishDate, cleaning, otherInfo, iD);
        }


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
