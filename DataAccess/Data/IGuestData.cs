using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IGuestData
    {
        Task DeleteGuest(int id);
        Task<GuestModel> GetGuest(int id);
        Task<IEnumerable<GuestModel>> GetGuests();
        Task InsertGuest(GuestModel guest);
        Task UpdateGuest(GuestModel guest);
        Task InsertGuestWithReservation(GuestModel guest, ReservationModel reservation);
    }
}