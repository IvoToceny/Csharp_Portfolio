using Dapper;
using MarketCarsLibrary.Data.Interfaces;
using MarketCarsLibrary.Db;
using MarketCarsLibrary.Models;

namespace MarketCarsLibrary.Data;

public class UsersData : IUsersData
{
    private IDataAccess dataAccess;
    private ConnectionStringData connectionString;

    public UsersData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        this.dataAccess = dataAccess;
        this.connectionString = connectionString;
    }

    public async Task<UsersModel> Create(UsersModel usersModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("Id", usersModel.Id);
        p.Add("UserName", usersModel.UserName);
        p.Add("PassWord", usersModel.PassWord);
        p.Add("Name", usersModel.Name);
        p.Add("Address", usersModel.Address);
        p.Add("Email", usersModel.Email);
        p.Add("PhoneNumber", usersModel.PhoneNumber);
        p.Add("Role", usersModel.Role);

        var user = await dataAccess.LoadData<UsersModel, dynamic>("dbo.spUsers_Create", p, connectionString.SqlConnectionName);

        return user.FirstOrDefault()!;
    }

    public Task<int> DeleteById(int id)
    {
        return dataAccess.SaveData("dbo.spUsers_DeleteById", new { Id = id }, connectionString.SqlConnectionName);
    }

    public async Task<UsersModel> GetUserById(int id)
    {
        var users = await dataAccess.LoadData<UsersModel, dynamic>("dbo.spUsers_GetUserById", new { Id = id }, connectionString.SqlConnectionName);

        return users.FirstOrDefault()!;
    }

    public Task<int> UpdateById(UsersModel usersModel)
    {
        DynamicParameters p = new DynamicParameters();

        p.Add("Id", usersModel.Id);
        p.Add("UserName", usersModel.UserName);
        p.Add("Password", usersModel.PassWord);
        p.Add("Name", usersModel.Name);
        p.Add("Address", usersModel.Address);
        p.Add("Email", usersModel.Email);
        p.Add("PhoneNumber", usersModel.PhoneNumber);
        p.Add("Role", usersModel.Role);

        return dataAccess.SaveData("dbo.spUsers_UpdateById", p, connectionString.SqlConnectionName);
    }
}
