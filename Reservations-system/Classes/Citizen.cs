﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations_system.Interfaces;

namespace Reservations_system.Classes
{
    public class Citizen : Guest, IReservation
    {
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
