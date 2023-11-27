using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Security.Claims;

namespace MarketCarsAPI.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class BlobsController : ControllerBase
{
    private readonly CloudBlobClient _blobClient;

    public BlobsController(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BlobStorage");
        var storageAccount = CloudStorageAccount.Parse(connectionString);
        _blobClient = storageAccount.CreateCloudBlobClient();
    }

    [HttpGet]
    public async Task<IActionResult> GetFiles()
    {
        var userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID not found.");
        }

        var userContainer = _blobClient.GetContainerReference(userId.ToLowerInvariant() + "-data");

        if (!await userContainer.ExistsAsync())
        {
            return Ok(new List<string>());
        }

        var blobs = await ListBlobsAsync(userContainer);

        return Ok(blobs);
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID not found.");
        }

        var userContainer = _blobClient.GetContainerReference(userId.ToLowerInvariant() + "-data");

        await userContainer.CreateIfNotExistsAsync();

        try
        {
            var blockBlob = userContainer.GetBlockBlobReference($"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}");

            using (var stream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(stream);
            }

            return Ok($"File {file.FileName} uploaded successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error uploading file: {ex.Message}");
        }
    }

    [HttpDelete("{fileName}")]
    public async Task<IActionResult> DeleteFile(string fileName)
    {
        var userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("User ID not found.");
        }

        var userContainer = _blobClient.GetContainerReference(userId.ToLowerInvariant() + "-data");

        if (!await userContainer.ExistsAsync())
        {
            return NotFound($"User container for {userId} not found.");
        }

        var blockBlob = userContainer.GetBlockBlobReference(fileName);

        if (await blockBlob.DeleteIfExistsAsync())
        {
            return Ok($"File {fileName} deleted successfully.");
        }

        return NotFound($"File {fileName} not found.");
    }

    private string? GetUserId()
    {
        //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        //return userIdClaim?.Value;

        return "2";
    }

    private async Task<IEnumerable<string>> ListBlobsAsync(CloudBlobContainer container)
    {
        var blobs = new List<string>();

        BlobContinuationToken? token = null;

        do
        {
            var resultSegment = await container.ListBlobsSegmentedAsync(token);
            token = resultSegment.ContinuationToken;

            foreach (IListBlobItem blobItem in resultSegment.Results)
            {
                if (blobItem is CloudBlockBlob blockBlob)
                {
                    blobs.Add(blockBlob.Name);
                }
            }
        } while (token != null);

        return blobs;
    }
}