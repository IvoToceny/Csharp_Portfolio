using Asp.Versioning;
using MarketCarsAPI.Models.BlobStorage;
using Microsoft.AspNetCore.Mvc;

namespace MarketCarsAPI.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class FilesController : ControllerBase
{
    private FileService fileService { get; }

    public FilesController(FileService fileService)
    {
        this.fileService = fileService;
    }

    // GET: api/<FilesController>
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<IActionResult> Get()
    {
        var result = await fileService.ListAsync();
        return Ok(result);
    }

    // POST api/<FilesController>
    [HttpPost]
    public async Task<IActionResult> Post(IFormFile file)
    {
        var result = await fileService.UploadAsync(file);
        return Ok(result);
    }

    // DELETE api/<FilesController>/test.jpg
    [HttpDelete("{fileName}")]
    public async Task<IActionResult> Delete(string fileName)
    {
        var result = await fileService.DeleteAsync(fileName);
        return Ok(result);
    }
}
