using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PingAFreelancerInfrastructure.Data;

public class DbInitializer
{

    public async Task SeedAsync(PingAFreelancerContext context)
    {
        await SeedDomainsAsync(context);
        await SeedExpertisesAsync(context);
        await SeedFreelancersAsync(context);
    }

    private async Task SeedDomainsAsync(PingAFreelancerContext context)
    {
        if (await _context.Domains.AnyAsync())
        {
            return;
        }

        var domains = new List<Domain>
        {
            new Domain { Id = -1, Name = "Labor" },
            new Domain { Id = -2, Name = "Domestic" },
            new Domain { Id = -3, Name = "Health" },
            new Domain { Id = -4, Name = "Lifestyle" },
            new Domain { Id = -5, Name = "Tech" },
        };

        _context.Domains.AddRange(domains);
        _context.SaveChanges();
    }
}