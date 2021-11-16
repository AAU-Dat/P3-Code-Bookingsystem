using Reservations_system.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Interfaces
{
    internal interface IReservation
    {
        public Reservation sendReservation();

        public void citizenHouseDelivered();

        public void citizenHouseRetrieved();

        public void reservationCancelled();
        
    }
}
