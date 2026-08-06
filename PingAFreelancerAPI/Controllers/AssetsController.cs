using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PingAFreelancerApplication.Assets;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AssetsController : ControllerBase
{
    private readonly IAssetStorage _assetStorage;

    public AssetsController(IAssetStorage assetStorage)
    {
        _assetStorage = assetStorage;
    }

    [HttpGet("{name}")]
    [ResponseCache(Duration = 604800, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> GetAsset(string name)
    {
        var asset = await _assetStorage.GetAssetAsync(name);
        if (asset is null) return NotFound();
        Response.Headers["X-Content-Type-Options"] = "nosniff";
        if (asset.ContentLength is { } length)
        {
            Response.ContentLength = length;
        }
        return File(asset.Content, asset.ContentType);
    }
}
