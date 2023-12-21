using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MarketCarsLibrary.Models;

public class ServicesModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[UserId] INT NOT NULL
    [Required]
    public string? UserId { get; set; }

    //[OrderDate] DATETIME2 NOT NULL
    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    //[ServiceDay] DATETIME2 NOT NULL
    [Required]
    public DateTime ServiceDay { get; set; }

    //[ServiceTime] NVARCHAR(50) NOT NULL
    [Required]
    public string? ServiceTime { get; set; }

    //[ServiceFinishEstimate] DATETIME2 NOT NULL
    [Required]
    public DateTime ServiceFinishEstimate { get; set; }

    //[ServiceDescription] NVARCHAR(400) NULL
    [MaxLength(100, ErrorMessage = "Service description needs to be under 400 characters")]
    public string? ServiceDescription { get; set; }

    //[CarId] INT NOT NULL
    [Required]
    public int CarId { get; set; }

    //[StateOfOrder] NVARCHAR(50) NOT NULL
    [Required]
    [MaxLength(50, ErrorMessage = "State of order needs to be under 50 characters")]
    [MinLength(1, ErrorMessage = "State of order needs to be longer than 0 characters")]
    public string? StateOfOrder { get; set; }
}
