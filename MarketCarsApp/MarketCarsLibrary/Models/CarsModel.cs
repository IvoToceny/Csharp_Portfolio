using System.ComponentModel.DataAnnotations;

namespace MarketCarsLibrary.Models;

public class CarsModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[OwnerId] INT NOT NULL
    [Required]
    public int OwnerId { get; set; }

    //[ForSale] BIT NOT NULL
    [Required]
    public bool ForSale { get; set; }

    //[Name] NVARCHAR(100) NOT NULL
    [Required]
    [MaxLength(100, ErrorMessage = "Car name needs to be under 100 characters")]
    [MinLength(1, ErrorMessage = "Car name needs to be longer than 1 character")]
    public string? Name { get; set; }

    //[Manufacturer] NVARCHAR(50) NOT NULL
    [Required]
    [MaxLength(50, ErrorMessage = "Car manufacturer needs to be under 50 characters")]
    [MinLength(1, ErrorMessage = "Car manufacturer needs to be longer than 1 character")]
    public string? Manufacturer { get; set; }

    //[Bodywork] NVARCHAR(20) NOT NULL
    [Required]
    public string? Bodywork { get; set; }

    //[Color] NVARCHAR(20) NOT NULL
    public string? Color { get; set; }

    //[EngineType] NVARCHAR(50) NULL
    [Required]
    [MaxLength(50, ErrorMessage = "EngineType needs to be under 50 characters")]
    [MinLength(1, ErrorMessage = "EngineType manufacturer needs to be longer than 1 character")]
    public string? EngineType { get; set; }

    //[HorsePower] NVARCHAR(20) NULL
    [Required]
    [MaxLength(20, ErrorMessage = "HorsePower needs to be under 20 characters")]
    [MinLength(1, ErrorMessage = "HorsePower needs to be longer than 1 character")]
    public string? HorsePower { get; set; }

    //[Mileage] INT NOT NULL
    [Required]
    [Range(1,int.MaxValue, ErrorMessage = "HorsePower needs to be higher than 0")]
    public int Mileage { get; set; }

    //[CarState] NVARCHAR(20) NULL
    public string? CarState { get; set; }

    //[Price] MONEY NULL
    public decimal Price { get; set; }
}
