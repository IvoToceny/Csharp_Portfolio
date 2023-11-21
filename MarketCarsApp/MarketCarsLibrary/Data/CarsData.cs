using Dapper;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;
using System.Data;

namespace MarketCarsLibrary.Data;

public class CarsData
{
    private IDataAccess dataAccess;
    private ConnectionStringData connectionString;

    public CarsData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> Create(CarsModel carsModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("OwnerId", carsModel.OwnerId);
        p.Add("ForSale", carsModel.ForSale);
        p.Add("Name", carsModel.Name);
        p.Add("Manufacturer", carsModel.Manufacturer);
        p.Add("Bodywork", carsModel.Bodywork);
        p.Add("Color", carsModel.Color);
        p.Add("EngineType", carsModel.EngineType);
        p.Add("HorsePower", carsModel.HorsePower);
        p.Add("Mileage", carsModel.Mileage);
        p.Add("CarState", carsModel.CarState);
        p.Add("Price", carsModel.Price);
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spCars_Create", p, connectionString.SqlConnectionName);

        return p.Get<int>("Id");
    }

    public Task<int> DeleteById(int id)
    {
        return dataAccess.SaveData("dbo.spCars_DeleteById", new { Id = id }, connectionString.SqlConnectionName);
    }

    public async Task<List<CarsModel>> GetAll()
    {
        return await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_GetAll", new {}, connectionString.SqlConnectionName);
    }

    public async Task<CarsModel> GetById(int id)
    {
        var cars = await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_GetById", new { Id = id }, connectionString.SqlConnectionName);

        return cars.FirstOrDefault()!;
    }

    public Task<int> UpdateById(CarsModel carsModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("Id", carsModel.Id);
        p.Add("ForSale", carsModel.ForSale);
        p.Add("Name", carsModel.Name);
        p.Add("Manufacturer", carsModel.Manufacturer);
        p.Add("Bodywork", carsModel.Bodywork);
        p.Add("Color", carsModel.Color);
        p.Add("EngineType", carsModel.EngineType);
        p.Add("HorsePower", carsModel.HorsePower);
        p.Add("Mileage", carsModel.Mileage);
        p.Add("CarState", carsModel.CarState);
        p.Add("Price", carsModel.Price);

        return dataAccess.SaveData("dbo.spCars_UpdateById", p, connectionString.SqlConnectionName);
    }
}
