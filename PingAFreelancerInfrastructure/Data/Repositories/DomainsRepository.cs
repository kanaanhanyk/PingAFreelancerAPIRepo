using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Domains;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class DomainsRepository : IDomainsRepository
{
    private readonly PingAFreelancerContext _context;

    public DomainsRepository(PingAFreelancerContext context)
    {
        _context = context;
    }

    public async Task<Domain> GetDomainAsync(int id)
    {
        return await _context.Domains.FindAsync(id);
    }
    public async Task<List<Domain>> GetDomainsAsync()
    {
        return await _context.Domains.ToListAsync();
    }
}