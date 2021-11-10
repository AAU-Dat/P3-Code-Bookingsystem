using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Reservations_system.Classes
{

    public class Reservation
    {
        public Reservation()
        {

        }
        public Reservation(DateTime startDate, DateTime finishDate, string firstName, string lastName, string phoneNumber,
                            string mail,string accountNumber, string registrationNumber, bool cleaning, bool isOver18, string otherInfo, int iD)
        {
            StartDate = startDate;
            FinishDate = finishDate;
            Cleaning = cleaning;
            OtherInfo =otherInfo;
            ID = iD;

            Guest guest = new Guest();
        }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime FinishDate { get; set; } = DateTime.Now.AddDays(1);

        public bool Cleaning { get; set; } = false;

        public string OtherInfo { get; set; }

        public int ID { get; set; }


    }


}
