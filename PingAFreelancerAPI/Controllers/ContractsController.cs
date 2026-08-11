using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Contracts;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContractsController : ControllerBase
{
    private readonly IContractsService _contractsService;

    public ContractsController(IContractsService contractsService)
    {
        _contractsService = contractsService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ContractResponse>> GetContractAsync(Guid id)
    {
        return Ok(await _contractsService.GetContractAsync(id));
    }

    [HttpGet("{freelancerId:guid}/{clientId:guid}")]
    public async Task<ActionResult<ContractsResponse>> GetContractsAsync(
        Guid freelancerId, Guid clientId, [FromQuery] ContractStatus contractStatus)
    {
        return Ok(await _contractsService.GetContractsAsync(freelancerId, clientId, contractStatus));
    }
}
