using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class xxxDummyData
    {
        private static DateTime firstDate = DateTime.Now.AddDays(1);
        private static DateTime secondDate = DateTime.Now.AddDays(3);
        private static DateTime thirdDate = DateTime.Now.AddDays(7);


        public static List<Guest> Guests = new List<Guest>()
        {
            new Guest("Mike Hunt", "88888888", "veryLongEmail@gmail.com", "my cunt", new ContactPerson()),
            new Guest("biggus Dickus", "22222222", "veryShortEmail@gmail.com", "bigdickus", new ContactPerson()),
            new Guest("Name", "12345678", "Mail@yahoo.com", "Address", new ContactPerson())
        };

        public static List<Reservation> ListOfReservations = new List<Reservation>()
        {
        new Reservation(Guests[0], firstDate, firstDate),
        new Reservation(Guests[1], secondDate, secondDate),
        new Reservation(Guests[2], thirdDate, thirdDate),
        };
        /*
        public static List<DateTime> RDates()
        {
            int i = 0;
            List<DateTime> lst = new List<DateTime>();
            foreach (Reservation item in ListOfReservations)
            {
                while (item.StartDate.AddDays(i) != item.EndDate.AddDays(1))
                {
                    lst.Add(item.StartDate.AddDays(i));
                    i ++;
                }
            }
            return lst;
        }*/
    }
}
