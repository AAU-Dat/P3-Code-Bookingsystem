using System;
using Reservations_system.Interfaces;

namespace Reservations_system.Classes
{
    public class Member : Guest, IReservation
    {
        public Member(string firstname, string lastname, string phonenumber, string mail, string address, string acconutnumber, string reg, bool isover18, DateTime startDate, DateTime finishDate,
            bool cleaning, string otherInfo, int iD) : base(firstname, lastname, phonenumber, mail, address, acconutnumber, reg, isover18, startDate, finishDate, cleaning, otherInfo, iD)
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
