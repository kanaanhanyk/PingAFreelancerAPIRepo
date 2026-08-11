using PingAFreelancerContracts;

using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Freelancers;

public interface IFreelancersRepository
{
    Task<Freelancer> GetFreelancerAsync(Guid id);
    Task<List<Freelancer>> GetFreelancersAsync(FreelancerQuery query);
}
