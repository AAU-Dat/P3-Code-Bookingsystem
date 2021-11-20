using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public class xxxDummyData
    {
        public static List<Guest> Guests = new List<Guest>()
        {
            new Guest("Mike Hunt", "88888888", "veryLongEmail@long.com", "my cunt", new ContactPerson()),
            new Guest("biggus Dickus", "22222222", "veryShortEmail@Short.com", "bigdickus", new ContactPerson()),
            new Guest("Name", "PhoneNumber", "Mail", "Address", new ContactPerson())
        };

        public static List<Reservation> ListOfReservations = new List<Reservation>()
        {
        new Reservation(Guests[0], new DateTime(2021, 11, 20), new DateTime(2021, 11, 22)),
        new Reservation(Guests[1], new DateTime(2021, 11, 24), new DateTime(2021, 11, 25)),
        new Reservation(Guests[2], new DateTime(2021, 11, 30), new DateTime(2021, 11, 30)),
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
