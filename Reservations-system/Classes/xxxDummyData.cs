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


        public static List<Guest> guests = new()
        {
            new Guest("Mike Mazowsky", "88888888", "verylongemailhere@gmail.com", "Torsvej 12", new ContactPerson(), "980321890132"),
            new Guest("John Wiener", "22222222", "shortmail@gmail.com", "Larspogade 19", new ContactPerson(), "0219321"),
            new Guest("Ukendt", "12345678", "mail@yahoo.com", "Ukendt Adresse", new ContactPerson(), "38970432")
        };

        public static List<Reservation> ListOfReservations = new()
        {
        new Reservation(guests[0], firstDate, firstDate),
        new Reservation(guests[1], secondDate, secondDate),
        new Reservation(guests[2], thirdDate, thirdDate),
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
