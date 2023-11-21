namespace MarketCarsLibrary.Models;

public class UsersModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    public int Id { get; set; }

    //[UserName] NVARCHAR(50) NOT NULL,
    public string? UserName { get; set; }

    //[PassWord] NVARCHAR(50) NOT NULL,
    public string? PassWord { get; set; }

    //[Name] NVARCHAR(50) NOT NULL,
    public string? Name { get; set; }

    //[Address] NVARCHAR(50) NULL,
    public string? Address { get; set; }

    //[Email] NVARCHAR(50) NOT NULL,
    public string? Email { get; set; }

    //[PhoneNumber] NVARCHAR(50) NULL,
    public string? PhoneNumber { get; set; }

    //[Role] NVARCHAR(50) NOT NULL
    public string? Role { get; set; }
}
