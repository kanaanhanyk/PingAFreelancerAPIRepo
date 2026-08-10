using PingAFreelancerContracts;
using PingAFreelancerCore.Entities;
using PingAFreelancerApplication.Freelancers;
using PingAFreelancerApplication.Expertises;

namespace PingAFreelancerApplication.Domains;

public static class ContractMappings
{
    public static DomainResponse MapToDomainResponse(this Domain domain)
    {
        return new DomainResponse(
            domain.Name,
            domain.PhotoPath,
            domain.Freelancers.MapToFreelancersResponse(),
            domain.Expertises.MapToExpertisesResponse()
        );
    }

    public static DomainsResponse MapToDomainsResponse(this List<Domain> domains)
    {
        return new DomainsResponse(
            domains
             .Select(d => d.MapToDomainResponse())
             .ToList()
        );
    }
}
