using Microsoft.Extensions.DependencyInjection;
using PingAFreelancerApplication.Domains;

namespace PingAFreelancerApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDomainsService, DomainsService>();
        return services;

    }
}