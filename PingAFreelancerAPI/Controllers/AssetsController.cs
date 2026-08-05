using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AssetsController : ControllerBase
{
    private readonly BlobContainerClient _blobContainerClient;

    public AssetsController(BlobServiceClient blobServiceClient)
    {
        _blobContainerClient = blobServiceClient.GetBlobContainerClient("assets");
    }

    [HttpGet("{name}")]
    [ResponseCache(Duration = 604800, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> GetAsset(string name)
    {
        var blobClient = _blobContainerClient.GetBlobClient(name);

        try
        {
            Response<BlobDownloadStreamingResult> download = await blobClient.DownloadStreamingAsync();

            Response.Headers["X-Content-Type-Options"] = "nosniff";
            Response.ContentLength = download.Value.Details.ContentLength;

            return File(download.Value.Content, download.Value.Details.ContentType);
        }
        catch (RequestFailedException ex) when (ex.Status == 404)
        {
            return NotFound();
        }

    }
}
