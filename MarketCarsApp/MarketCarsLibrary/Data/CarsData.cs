using Dapper;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;
using System.Data;

namespace MarketCarsLibrary.Data;

public class CarsData : ICarsData
{
    private readonly IDataAccess dataAccess;
    private readonly ConnectionStringData connectionString;

    public CarsData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<CarsModel> Create(CarsModel carsModel)
    {
        DynamicParameters p = new();

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

        var cars = await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_Create", p, connectionString.SqlConnectionName);

        return cars.FirstOrDefault()!;
    }

    public Task<int> DeleteById(int id)
    {
        return dataAccess.SaveData("dbo.spCars_DeleteById", new { Id = id }, connectionString.SqlConnectionName);
    }

    public async Task<List<CarsModel>> GetAll()
    {
        return await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_GetAll", new { }, connectionString.SqlConnectionName);
    }

    public async Task<List<CarsModel>> GetAllByUserId(string ownerId)
    {
        var cars = await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_GetAllByUserId", new { OwnerId = ownerId }, connectionString.SqlConnectionName);

        return cars;
    }

    public async Task<CarsModel> GetAllByUserAndCarId(string userId, int carId)
    {
        var car = await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_GetAllByUserAndCarId", new { Id = carId, OwnerId = userId }, connectionString.SqlConnectionName);

        return car.FirstOrDefault()!;
    }

    public async Task<CarsModel> UpdateById(CarsModel carsModel)
    {
        DynamicParameters p = new();

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

        var car = await dataAccess.LoadData<CarsModel, dynamic>("dbo.spCars_UpdateById", p, connectionString.SqlConnectionName);

        return car.FirstOrDefault()!;
    }
}
