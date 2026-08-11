using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PingAFreelancerInfrastructure.Data;
using Microsoft.Extensions.Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using PingAFreelancerInfrastructure.Storage;
using PingAFreelancerApplication.Assets;
using PingAFreelancerInfrastructure.Data.Repositories;
using PingAFreelancerApplication.Domains;
using PingAFreelancerApplication.Expertises;
using PingAFreelancerApplication.Freelancers;
using PingAFreelancerApplication.Clients;
using PingAFreelancerApplication.Contracts;

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
        services.AddScoped<IDomainsRepository, DomainsRepository>();
        services.AddScoped<IExpertisesRepository, ExpertisesRepository>();
        services.AddScoped<IFreelancersRepository, FreelancersRepository>();
        services.AddScoped<IClientsRepository, ClientsRepository>();
        services.AddScoped<IContractsRepository, ContractsRepository>();

        return services;
    }
}
