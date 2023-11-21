using Dapper;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCarsLibrary.Data;

public class ServicesData
{
    private IDataAccess dataAccess;
    private ConnectionStringData connectionString;

    public ServicesData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> Create(ServicesModel servicesModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("UserId", servicesModel.UserId);
        p.Add("OrderDate", servicesModel.OrderDate);
        p.Add("ServiceDay", servicesModel.ServiceDay);
        p.Add("ServiceTime", servicesModel.ServiceTime);
        p.Add("ServiceFinishEstimate", servicesModel.ServiceFinishEstimate);
        p.Add("ServiceDescription", servicesModel.ServiceDescription);
        p.Add("CarId", servicesModel.CarId);
        p.Add("StateOfOrder", servicesModel.StateOfOrder);
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spServices_Create", p, connectionString.SqlConnectionName);

        return p.Get<int>("Id");
    }

    public async Task<List<ServicesModel>> GetAll()
    {
        return await dataAccess.LoadData<ServicesModel, dynamic>("dbo.spServices_GetAll", new { }, connectionString.SqlConnectionName);
    }

    public async Task<ServicesModel> GetById(int id)
    {
        var cars = await dataAccess.LoadData<ServicesModel, dynamic>("dbo.spServices_GetById", new { Id = id }, connectionString.SqlConnectionName);

        return cars.FirstOrDefault()!;
    }

    public Task<int> UpdateById(ServicesModel servicesModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("OrderDate", servicesModel.OrderDate);
        p.Add("ServiceDay", servicesModel.ServiceDay);
        p.Add("ServiceTime", servicesModel.ServiceTime);
        p.Add("ServiceFinishEstimate", servicesModel.ServiceFinishEstimate);
        p.Add("ServiceDescription", servicesModel.ServiceDescription);
        p.Add("StateOfOrder", servicesModel.StateOfOrder);
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

        return dataAccess.SaveData("dbo.spServices_UpdateById", p, connectionString.SqlConnectionName);
    }
}
