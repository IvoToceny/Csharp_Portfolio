using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface ICarsData
    {
        Task<CarsModel> Create(CarsModel carsModel);
        Task<int> DeleteById(int id);
        Task<List<CarsModel>> GetAll();
        Task<CarsModel> GetById(int id);
        Task<CarsModel> UpdateById(CarsModel carsModel);
    }
}