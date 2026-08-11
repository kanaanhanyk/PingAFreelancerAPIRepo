using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Expertises;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class ExpertisesRepository : IExpertisesRepository
{
    private readonly PingAFreelancerContext _context;

    public ExpertisesRepository(PingAFreelancerContext context)
    {
        _context = context;
    }

    public async Task<Expertise> GetExpertiseAsync(int id)
    {
        return await _context.Expertises.FindAsync(id);
    }

    public async Task<List<Expertise>> GetExpertisesAsync()
    {
        return await _context.Expertises.ToListAsync();
    }
}
