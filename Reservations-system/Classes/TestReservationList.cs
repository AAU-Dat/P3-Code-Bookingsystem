using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations_system.Classes
{
    public static class TestReservationList
    {
        public static List<Reservation> ListOfReservations = new List<Reservation>(){

        new Reservation("Brown", "Watson", "748923", "this@yaoho.com", "Aalborg", "conto", "regnumbah", true,
            new DateTime(2021,7,3), new DateTime(2020,4,4), false, "no other info", 1),


        new Reservation("Bob", "Watson", "748923", "thi@yaoho.com", "Aalborg", "conto", "regnumbah", true,
            new DateTime(2021,7,3), new DateTime(2020,5,5), false, "no", 2),

        new Reservation("John", "Olaf", "123456789012345", "hotmail@yaoho.com", "Esbjerg", "27 27 27 27", "3838", true,
            new DateTime(2021,3,6), new DateTime(2020,6,6), true, "", 3),

    };

    }
}
