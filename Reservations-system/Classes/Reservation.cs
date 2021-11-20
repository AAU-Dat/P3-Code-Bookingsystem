using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public DateTime StartDate
        {
            get { return _startDate; }
            set { 
                //Ved ikke om vi kommer til at have brug for at tjekke om stardatoen er mindre end .Now (skal kalenderen have tekstfelt?)
                if(_startDate < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException("DateTime StartDate is earlier than DateTime.Now");
                }
                if(_startDate > EndDate)
                {
                    throw new ArgumentOutOfRangeException("DateTime StartDate is later than EndDate");
                }

                _startDate = value;
            }
        }
        [Required]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { 
                  if (_endDate < StartDate)
                {
                    throw new ArgumentOutOfRangeException("DateTime EndDate is earlier than StartDate");
                }
                //hvor mange dage må man booke ad gangen
                _endDate = value; 
            }
        }

        public string ReservationPeriod()
        {
            return $"{StartDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
        }
    }
}
