using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{

    public class Reservation
    {
        private Renter _guest;
        private bool _confirmed;
        private DateTime _startDate;
        private DateTime _endDate;

        public Reservation(Renter guest, DateTime start, DateTime end)
        {
            Guest = guest;
            StartDate = start;
                EndDate = end;
            Confirmed = false;
            
        }

        public Reservation()
        {
            Guest = new Guest();
        }

        public Renter Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }
        
        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string ReservationPeriod()
        {
            return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
        }
    }
}
