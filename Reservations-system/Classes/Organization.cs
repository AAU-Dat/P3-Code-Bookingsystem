using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class Organization
    {
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }

        public Reservation acceptReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation cancelReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation changeReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation declineReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void deleteReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void sendMail()
        {
            throw new NotImplementedException();
        }
    }
}
