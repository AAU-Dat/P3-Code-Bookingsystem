using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public interface ISqlDbAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U Parameters, string connectionId = "Default");
        Task SaveData<T>(string storedProcedure, T Parameters, string connectionId = "Default");
    }
}