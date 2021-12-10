using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class AssociationData : IAssociationData
    {
        private readonly ISqlDbAccess _db;

        public AssociationData(ISqlDbAccess db)
        {
            _db = db;
        }

        public Task DeleteAssociation(int id)
        {
            return _db.SaveData("dbo.spAssociation_Delete", new { Id = id });
        }
        public async Task<CitizenAssociationModel> GetAssociation(int id)
        {
            var results = await _db.LoadData<CitizenAssociationModel, dynamic>("dbo.spAssociation_Get", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task InsertAssociation(CitizenAssociationModel association)
        {
            return _db.SaveData("dbo.spAssociation_Insert", new
            {
                association.Name,
                association.Email,
                association.Address,
                association.Phone,
                association.InformationForGuests
            });
        }
        public Task UpdateAssociation(CitizenAssociationModel association)
        {
            return _db.SaveData("dbo.spAssociation_Update", association);
        }
    }
}
