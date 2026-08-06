using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;
using PingAFreelancerApplication.Assets;

namespace PingAFreelancerInfrastructure.Storage;

public sealed class BlobAssetStorage : IAssetStorage
{
    private readonly BlobContainerClient _blobContainerClient;

    public BlobAssetStorage(BlobServiceClient blobServiceClient)
    {
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("assets");
    }

    public async Task<AssetStreamResult?> GetAssetAsync(string name)
    {
        var blobClient = _blobContainerClient.GetBlobClient(name);
        try
        {
            var download = await blobClient.DownloadStreamingAsync();
            return new AssetStreamResult(
                download.Value.Content,
                download.Value.Details.ContentType,
                download.Value.Details.ContentLength
            );
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return null;
        }
    }
}

