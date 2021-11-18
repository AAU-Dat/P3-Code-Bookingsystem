using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class Citizen : Guest
    {
        public Citizen()
        {

        }
        public Citizen(string firstName, string lastName, string phoneNumber, string mail, 
            string address, string accountNumber, string registrationNumber, bool isOver18) : base(firstName, lastName, phoneNumber, mail, address,
                accountNumber, registrationNumber, isOver18)
        {

        }

        public void citizenHouseDelivered()
        {
            throw new NotImplementedException();
        }

        public void citizenHouseRetrieved()
        {
            throw new NotImplementedException();
        }

        public void reservationCancelled()
        {
            throw new NotImplementedException();
        }

        public Reservation sendReservation()
        {
            throw new NotImplementedException();
        }
    }
}
