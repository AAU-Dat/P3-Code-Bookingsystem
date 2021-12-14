using DataAccess.Models;
using Reservations_system.Classes;
using Reservations_system.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_ReservationsSystem.Test_Components
{
    class DataManagerTest : IDataManager
    {
        public DataManagerTest()
        {
            Guest guesttest = new Guest("Mike Mazowsky", "88888888", "verylongemailhere@gmail.com", "Torsvej 12", new ContactPerson(), "980321890132");

            Reservations.Add(new Reservation(guesttest, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2)));
        }

        public List<Reservation> Reservations => new();

        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
        }

        public Task<CitizenAssociationModel> GetAssociationInformation()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservationFromLocalList(int reservationId)
        {
            return Reservations.Find(p => p.Id == reservationId);
        }

        public Task<List<Reservation>> ReservationsDataFromDBAsync()
        {
            return Task.FromResult(Reservations);
        }

        public void UpdateAssociationInformation(CitizenAssociationModel association)
        {
            throw new NotImplementedException();
        }

        public void UpdateGuest(Renter guest)
        {
            Console.WriteLine(guest.Id);
        }

        public void UpdateReservation(Reservation reservation)
        {
            Console.WriteLine(reservation.Guest.Id);
        }
    }
}
