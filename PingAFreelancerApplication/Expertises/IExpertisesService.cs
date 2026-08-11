using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Expertises;

public interface IExpertisesService
{
    Task<ExpertiseResponse> GetExpertiseAsync(int id);
    Task<ExpertisesResponse> GetExpertisesAsync(int? domainId);
}
