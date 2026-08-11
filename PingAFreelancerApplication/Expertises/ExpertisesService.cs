using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Expertises;

public class ExpertisesService : IExpertisesService
{
    private readonly IExpertisesRepository _expertisesRepository;

    public ExpertisesService(IExpertisesRepository expertisesRepository)
    {
        _expertisesRepository = expertisesRepository;
    }

    public async Task<ExpertiseResponse> GetExpertiseAsync(int id)
    {
        var expertise = await _expertisesRepository.GetExpertiseAsync(id);
        return expertise.MapToExpertiseResponse();
    }

    public async Task<ExpertisesResponse> GetExpertisesAsync()
    {
        var expertises = await _expertisesRepository.GetExpertisesAsync();
        return expertises.MapToExpertisesResponse();
    }
}
