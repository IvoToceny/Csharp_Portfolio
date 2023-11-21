namespace MarketCarsLibrary.Models;

public class CarsModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[OwnerId] INT NOT NULL
    public int OwnerId { get; set; }

    //[ForSale] BIT NOT NULL
    public bool ForSale { get; set; }

    //[Name] NVARCHAR(100) NOT NULL
    public string? Name { get; set; }

    //[Manufacturer] NVARCHAR(50) NOT NULL
    public string? Manufacturer { get; set; }

    //[Bodywork] NVARCHAR(20) NOT NULL
    public string? Bodywork { get; set; }

    //[Color] NVARCHAR(20) NOT NULL
    public string? Color { get; set; }

    //[EngineType] NVARCHAR(50) NULL
    public string? EngineType { get; set; }

    //[HorsePower] NVARCHAR(20) NULL
    public string? HorsePower { get; set; }

    //[Mileage] INT NOT NULL
    public int Mileage { get; set; }

    //[CarState] NVARCHAR(20) NULL
    public string? CarState { get; set; }

    //[Price] MONEY NULL
    public decimal Price { get; set; }
}
