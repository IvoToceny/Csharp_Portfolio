using MarketCarsAPI.Models.BlobStorage;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
}
