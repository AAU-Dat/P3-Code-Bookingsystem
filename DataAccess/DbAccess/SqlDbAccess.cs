﻿using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DbAccess
{
    public class SqlDbAccess : ISqlDbAccess
    {
        private readonly IConfiguration _config;

        public SqlDbAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure, U Parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(
                storedProcedure, Parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedure, T Parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(
                storedProcedure, Parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
