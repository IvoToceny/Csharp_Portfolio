namespace MarketCarsLibrary.Models;

public class ServicesModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[UserId] INT NOT NULL
    public int UserId { get; set; }

    //[OrderDate] DATETIME2 NOT NULL
    public DateTime OrderDate { get; set; }

    //[ServiceDay] DATETIME2 NOT NULL
    public DateTime ServiceDay { get; set; }

    //[ServiceTime] NVARCHAR(50) NOT NULL
    public string? ServiceTime { get; set; }

    //[ServiceFinishEstimate] DATETIME2 NOT NULL
    public DateTime ServiceFinishEstimate { get; set; }

    //[ServiceDescription] NVARCHAR(400) NOT NULL
    public string? ServiceDescription { get; set; }

    //[CarId] INT NOT NULL
    public int CarId { get; set; }

    //[StateOfOrder] NVARCHAR(50) NOT NULL
    public string? StateOfOrder { get; set; }
}
