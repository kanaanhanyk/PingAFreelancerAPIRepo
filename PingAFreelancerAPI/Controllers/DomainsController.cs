using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Domains;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DomainsController : ControllerBase
{
    private readonly IDomainsService _domainsService;
    public DomainsController(IDomainsService domainsService)
    {
        _domainsService = domainsService;
    }

    [HttpGet]
    public async Task<ActionResult<DomainsResponse>> GetDomainsAsync()
    {
        return Ok(await _domainsService.GetDomainsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DomainResponse>> GetDomainAsync(int id)
    {
        return Ok(await _domainsService.GetDomainAsync(id));
    }


}

