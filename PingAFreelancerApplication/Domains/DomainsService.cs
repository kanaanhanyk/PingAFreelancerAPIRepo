using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Domains;

public class DomainsService : IDomainsService
{
    private readonly IDomainsRepository _domainsRepository;
    public DomainsService(IDomainsRepository domainsRepository)
    {
        _domainsRepository = domainsRepository;

    }
    public async Task<DomainResponse> GetDomainAsync(int id)
    {
        var domain = await _domainsRepository.GetDomainAsync(id);
        var domainResponse = domain.MapToDomainResponse();
        return await Task.FromResult(domainResponse);
    }
    public async Task<DomainsResponse> GetDomainsAsync()
    {
        var domains = await _domainsRepository.GetDomainsAsync();
        return domains.MapToDomainsResponse();
    }
}