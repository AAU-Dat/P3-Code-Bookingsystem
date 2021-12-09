using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public interface IAssociationData
    {
        Task DeleteAssociation(int id);
        Task<CitizenAssociationModel> GetAssociation(int id);
        Task InsertAssociation(CitizenAssociationModel association);
        Task UpdateAssociation(CitizenAssociationModel association);
    }
}