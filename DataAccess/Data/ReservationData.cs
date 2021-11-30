using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ReservationData : IReservationData
    {
        private readonly ISqlDbAccess _db;

        public ReservationData(ISqlDbAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<ReservationModel>> GetReservations()
        {
            return _db.LoadData<ReservationModel, dynamic>("dbo.spReservation_GetAll", new { });
        }

        public async Task<ReservationModel> GetReservation(int id)
        {
            var results = await _db.LoadData<ReservationModel, dynamic>("dbo.spReservation_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertReservation(ReservationModel reservation)
        {
            return _db.SaveData(
                "dbo.spReservation_Insert",
                new { reservation.StartDate, reservation.EndDate, reservation.GuestId });
        }

        public Task UpdateReservation(ReservationModel reservation)
        {
            return _db.SaveData("dbo.spReservation_Update", reservation);
        }

        public Task DeleteReservation(int id)
        {
            return _db.SaveData("dbo.spReservation_Delete", new { Id = id });
        }
    }
}
