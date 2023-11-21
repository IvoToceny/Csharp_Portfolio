using Dapper;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;
using System.Data;

namespace MarketCarsLibrary.Data;

public class ImagesData
{
    private IDataAccess dataAccess;
    private ConnectionStringData connectionString;

    public ImagesData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<int> Create(ImagesModel imagesModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("CarId", imagesModel.CarId);
        p.Add("Path", imagesModel.Path);
        p.Add("IsHeadPhoto", imagesModel.IsHeadPhoto);
        p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

        await dataAccess.SaveData("dbo.spImages_Create", p, connectionString.SqlConnectionName);

        return p.Get<int>("Id");
    }

    public Task<int> DeleteById(int id)
    {
        return dataAccess.SaveData("dbo.spImages_DeleteById", new { Id = id }, connectionString.SqlConnectionName);
    }

    public async Task<List<ImagesModel>> GetAllByCarId(int carId)
    {
        return await dataAccess.LoadData<ImagesModel, dynamic>("dbo.spImages_GetAllByCarId", new { CarId = carId}, connectionString.SqlConnectionName);
    }

    public async Task<ImagesModel> GetFirstByCarId(int id)
    {
        var images = await dataAccess.LoadData<ImagesModel, dynamic>("dbo.spImages_GetFirstByCarId", new { Id = id }, connectionString.SqlConnectionName);

        return images.FirstOrDefault()!;
    }
}
