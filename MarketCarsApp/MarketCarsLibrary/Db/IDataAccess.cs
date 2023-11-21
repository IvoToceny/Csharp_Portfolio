namespace MarketCarsLibrary.Db;

public interface IDataAccess
{
    Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);

    Task<int> LoadData<U>(string storedProcedure, U parameters, string connectionStringName);
}