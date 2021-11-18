using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{

    public class Reservation
    {
        private Guest _guest;
        private List<DateTime> _reservedDates;
        private bool _confirmed;//gik ud fr at det var det status betød
        //private bool _cleaning;

        public Reservation(Guest guest, DateTime start, DateTime end/*, bool cleaning*/)
        {
            Guest = guest;
            SetReservedDates(start, end);
            Confirmed = false;
            //Cleaning = cleaning;
        }

        public Reservation()
        {
            Guest = new Guest();
        }

        public Guest Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public List<DateTime> ReservedDates
        {
            get { return _reservedDates; }
            set { _reservedDates = value; }
        }
        
        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        /*
        public bool Cleaning
        {
            get { return _cleaning; }
            set { _cleaning = value; }
        }
        */

        public string ReservationPeriod()
        {
            return $"{ReservedDates[0].ToShortDateString()} - {ReservedDates[ReservedDates.Count-1].ToShortDateString()}";
        }

        public void SetReservedDates(DateTime Start, DateTime End)
        {
            ReservedDates = new List<DateTime>();
            int i = 0;
            while (Start.AddDays(i) != End.AddDays(1))
            {
                ReservedDates.Add(Start.AddDays(i));
                i++;
            }
        }

        public void SetStartDate(DateTime Start)
        {
            DateTime End = ReservedDates[ReservedDates.Count];
            ReservedDates = new List<DateTime>();
            int i = 0;
            while (Start.AddDays(i) != End.AddDays(1))
            {
                ReservedDates.Add(Start.AddDays(i));
                i++;
            }
        }

        public void SetEndDate(DateTime End)
        {
            DateTime Start = ReservedDates[0];
            ReservedDates = new List<DateTime>();
            int i = 0;
            while (Start.AddDays(i) != End.AddDays(1))
            {
                ReservedDates.Add(Start.AddDays(i));
                i++;
            }
        }

        public DateTime GetStartDate()
        {
            return ReservedDates[0];
        }

        public DateTime GetEndDate()
        {
            return ReservedDates[ReservedDates.Count];
        }


    }

}
