using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PingAFreelancerInfrastructure.Data;
using Microsoft.Extensions.Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using PingAFreelancerInfrastructure.Storage;
using PingAFreelancerApplication.Assets;

namespace PingAFreelancerInfrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PingAFreelancerContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddAzureClients(clients =>
            {
                clients.AddBlobServiceClient(new Uri(configuration.GetConnectionString("BlobEndpoint")));
                clients.UseCredential(new DefaultAzureCredential());
            });

        services.AddScoped<IAssetStorage, BlobAssetStorage>();


        return services;
    }
}
