using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface IImagesData
    {
        Task<int> Create(ImagesModel imagesModel);
        Task<int> DeleteById(int id);
        Task<List<ImagesModel>> GetAllByCarId(int carId);
        Task<ImagesModel> GetFirstByCarId(int id);
    }
}