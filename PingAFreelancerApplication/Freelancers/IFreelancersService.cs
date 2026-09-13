using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Freelancers;

public interface IFreelancersService
{
    Task<FreelancerResponse> GetFreelancerAsync(Guid id);
    Task<FreelancersResponse> GetFreelancersAsync(FreelancerQuery query);
    Task<int> GetFreelancersCountAsync(FreelancerQuery query);
}
