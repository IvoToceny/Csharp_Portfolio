using System.ComponentModel.DataAnnotations;

namespace MarketCarsLibrary.Models;

public class ImagesModel
{
    //[Id] INT NOT NULL PRIMARY KEY IDENTITY
    public int Id { get; set; }

    //[CarId] INT NOT NULL
    [Required]
    public int CarId { get; set; }

    //[Path] NVARCHAR(100) NOT NULL
    [Required]
    [MaxLength(1000, ErrorMessage = "Image path needs to be under 1000 characters")]
    [MinLength(1, ErrorMessage = "Image path needs to be longer than 0 character")]
    public string? Path { get; set; }

    //[IsHeadPhoto] BIT NOT NULL
    [Required]
    public bool IsHeadPhoto { get; set; }
}
