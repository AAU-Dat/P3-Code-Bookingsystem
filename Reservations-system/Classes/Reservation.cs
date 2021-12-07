using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace Reservations_system.Classes
{

    public class Reservation
    {
        private int _id;
        private Renter _guest;
        private DateTime? _confirmed;
        private DateTime _startDate;
        private DateTime _endDate;

        public Reservation(Renter guest, DateTime start, DateTime end)
        {
            Guest = guest;
            StartDate = start;
            EndDate = end;
        }

        public Reservation()
        {
            Guest = new Guest();
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public Renter Guest
        {
            get { return _guest; }
            set { _guest = value; }
        }

        public DateTime? Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        [Required]
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
            }
        }
        [Required]
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
            }
        }

        public string ReservationPeriod()
        {
            return $"{StartDate:dd MMM yyyy} - {EndDate:dd MMM yyyy}";
        }
    }
}
