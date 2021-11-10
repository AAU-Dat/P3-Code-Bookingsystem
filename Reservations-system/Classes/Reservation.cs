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

        }
        public Reservation(DateTime startDate, DateTime finishDate, bool cleaning, string otherInfo, int iD)
        {
            //Erstat evt. start og finishdate med Liste af dage 
            StartDate = startDate;
            FinishDate = finishDate;
            Cleaning = cleaning;
            OtherInfo =otherInfo;
            ID = iD;
        }
       
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime FinishDate { get; set; } = DateTime.Now.AddDays(1);

        public bool Cleaning { get; set; } = false;

        public string OtherInfo { get; set; }

        public int ID { get; set; }


        public void ReservationSend() { }
    }


}
