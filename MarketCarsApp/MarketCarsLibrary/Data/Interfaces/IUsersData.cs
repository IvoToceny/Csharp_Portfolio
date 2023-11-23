using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data.Interfaces
{
    public interface IUsersData
    {
        Task<UsersModel> Create(UsersModel usersModel);
        Task<int> DeleteById(int id);
        Task<UsersModel> GetUserById(int id);
        Task<int> UpdateById(UsersModel usersModel);
    }
}