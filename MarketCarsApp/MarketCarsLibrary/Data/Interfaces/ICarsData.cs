using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface ICarsData
    {
        Task<int> Create(CarsModel carsModel);
        Task<int> DeleteById(int id);
        Task<List<CarsModel>> GetAll();
        Task<CarsModel> GetById(int id);
        Task<int> UpdateById(CarsModel carsModel);
    }
}