namespace PingAFreelancerApplication.Assets;

public interface IAssetStorage
{
    Task<AssetStreamResult?> GetAssetAsync(string name);
}

public sealed record AssetStreamResult(Stream Content, string ContentType, long? ContentLength);
