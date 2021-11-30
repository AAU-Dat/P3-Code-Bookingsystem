using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IReservationData
    {
        Task DeleteReservation(int id);
        Task<ReservationModel> GetReservation(int id);
        Task<IEnumerable<ReservationModel>> GetReservations();
        Task InsertReservation(ReservationModel reservation);
        Task UpdateReservation(ReservationModel reservation);
    }
}