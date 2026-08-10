using PingAFreelancerContracts;
using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Expertises;

public static class ContractMappings
{
    public static ExpertiseResponse MapToExpertiseResponse(this Expertise expertise)
    {
        return new ExpertiseResponse(
            expertise.Id,
            expertise.DomainId,
            expertise.Name,
            expertise.PhotoPath
        );
    }

    public static ExpertisesResponse MapToExpertisesResponse(this ICollection<Expertise> expertises)
    {
        return new ExpertisesResponse(
            expertises.Select(MapToExpertiseResponse).ToList()
        );
    }
}