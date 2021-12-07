using Reservations_system.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reservations_system.Data
{
    public interface IDataManager
    {
        List<Reservation> Reservations { get; }
        void AddReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Reservation GetReservationFromLocalList(int reservationId);
        Task<List<Reservation>> ReservationsDataFromDBAsync();
        void UpdateGuest(Guest guest);
        void UpdateReservation(Reservation reservation);
    }
}