using DataAccess.Data;
using DataAccess.Models;
using Reservations_system.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reservations_system.Data
{
    public class DataManager
    {
        private readonly IReservationData reservationDataAccess;
        public IEnumerable<Reservation> reservations { get; set; }
        //private IEnumerable<Reservation> _reservations { get; set; }

        public DataManager(IReservationData reservationDataAccess)
        {
            this.reservationDataAccess = reservationDataAccess;
        }
        public void GetReservations() //Creates object of reservations from DB, might need better name
        {
            reservations = (IEnumerable<Reservation>)reservationDataAccess.GetReservations();
        }

        public void AddReservation(Reservation reservation)
        {
            List<Reservation> list = reservations.ToList();
            list.Add(reservation);
            reservations = list;
        }
    }
}
//Create list of reservations with guests in
//Create a number of methods to update lists, locally and in DB
//Make it an interface and add it as singleton transient dependecy thing
//Update models, Guests reservation etc..... Remove shitty validation make better
