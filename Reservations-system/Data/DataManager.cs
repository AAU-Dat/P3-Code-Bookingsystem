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
        private readonly IGuestData guestDataAccess;
        public IEnumerable<Reservation> reservations { get; set; }

        //public DataManager(IReservationData reservationDataAccess)
        //{
        //    this.reservationDataAccess = reservationDataAccess;
        //}

        //public void GetReservations() //Creates object of reservations from DB, might need better name, and maybe a return type
        //{
        //    reservations = (IEnumerable<Reservation>)reservationDataAccess.GetReservations();
        //}

        public void AddReservation(Reservation reservation)
        {
            guestDataAccess.InsertGuest(new GuestModel()
            {
                Name = reservation.Guest.Name,
                Address = reservation.Guest.Address,
                Phone = reservation.Guest.PhoneNumber,
                Email = reservation.Guest.Mail,
                AccountNumber = reservation.Guest.AccountNumber
            });
            reservationDataAccess.InsertReservation(new ReservationModel()
            {
                GuestId = reservation.Guest.Id,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            });
            List<Reservation> list = reservations.ToList();
            list.Add(reservation);
            reservations = list;
        }

        //public void AddGuest(Guest guest) //Måske en hjælpe funktion til AddReservation?
        //{
        //
        //}
    }
}
//Create list of reservations with guests in
//Create a number of methods to update lists, locally and in DB
//Make it an interface and add it as singleton transient dependecy thing
//Update models, Guests reservation etc..... Remove shitty validation make better
