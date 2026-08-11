using Microsoft.Extensions.DependencyInjection;
using PingAFreelancerApplication.Domains;
using PingAFreelancerApplication.Expertises;
using PingAFreelancerApplication.Freelancers;
using PingAFreelancerApplication.Clients;
using PingAFreelancerApplication.Contracts;

namespace PingAFreelancerApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDomainsService, DomainsService>();
        services.AddScoped<IExpertisesService, ExpertisesService>();
        services.AddScoped<IFreelancersService, FreelancersService>();
        services.AddScoped<IClientsService, ClientsService>();
        services.AddScoped<IContractsService, ContractsService>();

        return services;
    }
}