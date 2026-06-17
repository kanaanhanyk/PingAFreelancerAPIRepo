using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingAFreelancerApplication;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDebContext<PingAFreelancerContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}


