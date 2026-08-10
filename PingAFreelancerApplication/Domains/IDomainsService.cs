using PingAFreelancerApplication.Domains;
using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Domains;

public interface IDomainsService
{
    Task<DomainResponse> GetDomainAsync(int id);
    Task<DomainsResponse> GetDomainsAsync();
}