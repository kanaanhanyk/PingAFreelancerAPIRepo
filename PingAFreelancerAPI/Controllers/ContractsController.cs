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

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractResponse>> GetContractAsync(Guid id)
    {
        return Ok(await _contractsService.GetContractAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<ContractsResponse>> GetContractsAsync()
    {
        return Ok(await _contractsService.GetContractsAsync());
    }
}
