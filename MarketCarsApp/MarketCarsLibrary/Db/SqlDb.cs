﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace MarketCarsLibrary.Db;

public class SqlDb : IDataAccess
{
    private IConfiguration config { get; }

    public SqlDb(IConfiguration config)
    {
        this.config = config;
    }

    public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        var connectionString = config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var rows = await connection.QueryAsync<T>(storedProcedure,
                                                      parameters,
                                                      commandType: CommandType.StoredProcedure);

            return rows.ToList();
        }
    }

    public async Task<int> SaveData<U>(string storedProcedure, U parameters, string connectionStringName)
    {
        var connectionString = config.GetConnectionString(connectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            return await connection.ExecuteAsync(storedProcedure,
                                                 parameters,
                                                 commandType: CommandType.StoredProcedure);
        }
    }
}
