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
        private bool _confirmed;
        private bool _cleaning;
        private string _otherInfo;
        private int _id;

        public Reservation(Guest guest, DateTime start, DateTime end, bool confirmed, bool cleaning, string otherInfo, int id)
        {
            Guest = guest;
            SetReservedDates(start, end);
            Confirmed = confirmed;
            Cleaning = cleaning;
            OtherInfo = otherInfo;
            Id = id;

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


        public bool Cleaning
        {
            get { return _cleaning; }
            set { _cleaning = value; }
        }


        public string OtherInfo
        {
            get { return _otherInfo; }
            set { _otherInfo = value; }
        }


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string ReservationFormatDates()
        {
            return $"{ReservedDates[0].ToShortDateString()} - {ReservedDates[ReservedDates.Count].ToShortDateString()}";
        }

        public void SetReservedDates(DateTime start, DateTime end)
        { 
            int i = 0;
            while (start.AddDays(i) != end)
            {
                ReservedDates.Add(start.AddDays(i));
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
