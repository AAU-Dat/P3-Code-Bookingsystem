using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{

    public class Reservation
    {
        public Reservation()
        {
            CitizenGuest = new();
        }
        public Reservation(string firstName, string lastName, string phoneNumber, string mail, string address, string acconutNumber,
            string reg, bool isover18, DateTime startDate, DateTime finishDate, bool cleaning, string otherInfo, int iD)
        {
            StartDate = startDate;
            FinishDate = finishDate;
            Cleaning = cleaning;
            OtherInfo = otherInfo;
            ID = iD;

            CitizenGuest = new Citizen(firstName, lastName, phoneNumber, mail, address, acconutNumber, reg, isover18);
        }
        public Citizen CitizenGuest {get;set;}
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime FinishDate { get; set; } = DateTime.Now.AddDays(1);

        public bool Cleaning { get; set; } = false;

        public string OtherInfo { get; set; }

        public int ID { get; set; }

        public bool Confirmed { get; set; } = false;

        public void ReservationSend() { }

        public string ReservationFormatDates()
        {
            return $"{StartDate.ToShortDateString()} - {FinishDate.ToShortDateString()}";
        }
    }


}
