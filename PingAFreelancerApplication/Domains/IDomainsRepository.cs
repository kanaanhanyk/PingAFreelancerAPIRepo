using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Domains;

public interface IDomainsRepository
{
    Task<Domain> GetDomainAsync(int id);
    Task<List<Domain>> GetDomainsAsync();
}