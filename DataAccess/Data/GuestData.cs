using DataAccess.DbAccess;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class GuestData : IGuestData
    {
        private readonly ISqlDbAccess _db;

        public GuestData(ISqlDbAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<GuestModel>> GetGuests()
        {
            return _db.LoadData<GuestModel, dynamic>("dbo.spGuest_GetAll", new { });
        }

        public async Task<GuestModel> GetGuest(int id)
        {
            var results = await _db.LoadData<GuestModel, dynamic>("dbo.spGuest_Get", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertGuest(GuestModel guest)
        {
            return _db.SaveData(
                "dbo.spGuest_Insert",
                new { guest.Name, guest.Address, guest.Email, guest.Phone, guest.AccountNumber });
        }

        public Task UpdateGuest(GuestModel guest)
        {
            return _db.SaveData("dbo.spGuest_Update", guest);
        }

        public Task DeleteGuest(int id)
        {
            return _db.SaveData("dbo.spGuest_Delete", new { Id = id });
        }
    }
}
