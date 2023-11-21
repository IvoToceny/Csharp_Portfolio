using Azure.Storage;
using Azure.Storage.Blobs;

namespace MarketCarsAPI.Models.BlobStorage;

public class FileService
{
    private BlobContainerClient filesContainer;
    private readonly IConfiguration configuration;

    public FileService(IConfiguration configuration)
    {
        this.configuration = configuration;
        string storageAccount = configuration.GetValue<string>("FilesStorage:StorageAccount")!;
        string key = configuration.GetValue<string>("FilesStorage:Key")!;

        StorageSharedKeyCredential credential = new StorageSharedKeyCredential(storageAccount, key);
        string blobUri = configuration.GetValue<string>("FilesStorage:BlobUri")!;
        BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
        filesContainer = blobServiceClient.GetBlobContainerClient("images");
    }

    public async Task<List<BlobDto>> ListAsync()
    {
        List<BlobDto> files = new List<BlobDto>();

        await foreach (var file in filesContainer.GetBlobsAsync())
        {
            string blobUri = configuration.GetValue<string>("FilesStorage:BlobUri")!;
            var name = file.Name;
            var fullUri = $"{blobUri}/{name}";

            files.Add(new BlobDto
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType,
            });
        }

        return files;
    }

    public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
    {
        BlobResponseDto response = new BlobResponseDto();
        BlobClient client = filesContainer.GetBlobClient(blob.FileName);

        await using (Stream? data = blob.OpenReadStream())
        {
            await client.UploadAsync(data);
        }

        try
        {
            response.Status = $"File {blob.FileName} Uploaded Successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = blob.FileName;
        }
        catch
        {
            response.Status = $"File {blob.FileName} Upload Failed";
            response.Error = true;
        }

        return response;
    }

    public async Task<BlobResponseDto> DeleteAsync(string fileName)
    {
        BlobClient file = filesContainer.GetBlobClient(fileName);
        await file.DeleteAsync();

        return new BlobResponseDto
        {
            Error = false,
            Status = $"File {fileName} Deleted Successfully"
        };
    }
}
