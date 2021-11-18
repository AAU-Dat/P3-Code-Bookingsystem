using System;

namespace Reservations_system.Classes
{
    public class Member : Guest
    {
        public Member(string firstName, string lastName, string phoneNumber, string mail, string address, string accountNumber,
            string registrationNumber, bool isOver18) : base(firstName, lastName, phoneNumber, mail, address, accountNumber, registrationNumber, isOver18)
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
