using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Freelancers;

public class FreelancersService : IFreelancersService
{
    private readonly IFreelancersRepository _freelancersRepository;

    public FreelancersService(IFreelancersRepository freelancersRepository)
    {
        _freelancersRepository = freelancersRepository;
    }

    public async Task<FreelancerResponse> GetFreelancerAsync(Guid id)
    {
        var freelancer = await _freelancersRepository.GetFreelancerAsync(id);
        return freelancer.MapToFreelancerResponse();
    }

    public async Task<FreelancersResponse> GetFreelancersAsync(FreelancerQuery query)
    {
        var freelancers = await _freelancersRepository.GetFreelancersAsync(query);
        return freelancers.MapToFreelancersResponse();
    }
}
