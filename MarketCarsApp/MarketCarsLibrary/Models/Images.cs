namespace MarketCarsLibrary.Models;

public class Images
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[CarId] INT NOT NULL
    public int CarId { get; set; }

    //[Path] NVARCHAR(100) NOT NULL
    public string? Path { get; set; }

    //[IsHeadPhoto] BIT NOT NULL
    public bool IsHeadPhoto { get; set; }
}
