using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MarketCarsLibrary.Models;

public class UsersModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    public int Id { get; set; }

    //[UserName] NVARCHAR(50) NOT NULL,
    [Required]
    [MaxLength(50, ErrorMessage = "Username needs to be under 50 characters")]
    [MinLength(5, ErrorMessage = "Username needs to be longer than 4 characters")]
    [DisplayName("Unique login name")]
    public string? UserName { get; set; }

    //[PassWord] NVARCHAR(50) NOT NULL,
    [Required]
    [PasswordPropertyText]
    [MaxLength(50, ErrorMessage = "Password needs to be under 50 characters")]
    [MinLength(8, ErrorMessage = "Password needs to be longer than 7 characters")]
    public string? PassWord { get; set; }

    //[Name] NVARCHAR(50) NOT NULL,
    [Required]
    [MaxLength(50, ErrorMessage = "Name needs to be under 50 characters")]
    [MinLength(2, ErrorMessage = "Name needs to be longer than 1 characters")]
    public string? Name { get; set; }

    //[Address] NVARCHAR(50) NULL,
    public string? Address { get; set; }

    //[Email] NVARCHAR(50) NOT NULL,
    [Required]
    [EmailAddress]
    [MaxLength(50, ErrorMessage = "Email address needs to be under 50 characters")]
    [MinLength(2, ErrorMessage = "Email address needs to be longer than 1 characters")]
    public string? Email { get; set; }

    //[PhoneNumber] NVARCHAR(50) NULL,
    [Phone]
    public string? PhoneNumber { get; set; }

    //[Role] NVARCHAR(50) NOT NULL
    [Required]
    [MaxLength(50, ErrorMessage = "Role needs to be under 50 characters")]
    public string? Role { get; set; }
}
