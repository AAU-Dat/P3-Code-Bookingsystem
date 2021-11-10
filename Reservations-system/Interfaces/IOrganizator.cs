using Reservations_system.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Interfaces
{
    internal interface IOrganizator
    {
        public void deleteReservation(Reservation reservation);

        public Reservation changeReservation(Reservation reservation);

        public Reservation cancelReservation(Reservation reservation);

        public Reservation acceptReservation(Reservation reservation);

        public Reservation declineReservation(Reservation reservation);

        public void sendMail();
    }
}
