using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface IServicesData
    {
        Task<int> Create(ServicesModel servicesModel);
        Task<List<ServicesModel>> GetAll();
        Task<ServicesModel> GetById(int id);
        Task<int> UpdateById(ServicesModel servicesModel);
    }
}