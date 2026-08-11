using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Expertises;

public interface IExpertisesRepository
{
    Task<Expertise> GetExpertiseAsync(int id);
    Task<List<Expertise>> GetExpertisesAsync(int? domainId);
}
