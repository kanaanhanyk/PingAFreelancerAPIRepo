using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Freelancers;
using PingAFreelancerContracts;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class FreelancersRepository : IFreelancersRepository
{
    private readonly PingAFreelancerContext _context;

    public FreelancersRepository(PingAFreelancerContext context)
    {
        _context = context;
    }

    public async Task<Freelancer> GetFreelancerAsync(Guid id)
    {
        return await _context.Freelancers.FindAsync(id);
    }

    public async Task<List<Freelancer>> GetFreelancersAsync(FreelancerQuery query)
    {
        var freelancers = _context.Freelancers.AsQueryable();

        if (query.DomainId.HasValue)
            freelancers = freelancers.Where(f => f.DomainId == query.DomainId.Value);
        if (query.ExpertiseId.HasValue)
            freelancers = freelancers.Where(f => f.ExpertiseId == query.ExpertiseId.Value);
        if (query.MaxHourlyRate.HasValue)
            freelancers = freelancers.Where(f => f.HourlyRate <= query.MaxHourlyRate.Value);
        if (query.MinHoursBilled.HasValue)
            freelancers = freelancers.Where(f => f.HoursBilled >= query.MinHoursBilled.Value);
        if (query.MinTotalEarned.HasValue)
            freelancers = freelancers.Where(f => f.TotalEarned >= query.MinTotalEarned.Value);
        if (query.MinInteractionCount.HasValue)
            freelancers = freelancers.Where(f => f.InteractionCount >= query.MinInteractionCount.Value);
        if (query.MinRatingSum.HasValue)
            freelancers = freelancers.Where(f => f.RatingSum >= query.MinRatingSum.Value);

        return await freelancers.ToListAsync();
    }
}
