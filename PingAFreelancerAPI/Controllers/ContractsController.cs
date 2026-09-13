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

    [HttpGet("{id:guid}", Name = "GetContract")]
    public async Task<ActionResult<ContractResponse>> GetContractAsync(Guid id)
    {
        return Ok(await _contractsService.GetContractAsync(id));
    }

    [HttpGet("{freelancerId:guid}/{clientId:guid}")]
    public async Task<ActionResult<ContractsResponse>> GetContractsAsync(
        Guid freelancerId, Guid clientId)
    {
        return Ok(await _contractsService.GetContractsAsync(freelancerId, clientId));
    }

    [HttpPost]
    public async Task<ActionResult<ContractResponse>> PingAsync(ContractRequest request)
    {
        var response = await _contractsService.PingAsync(request);
        return CreatedAtRoute("GetContract", new { id = response.Id }, response);
    }

    [HttpPut("{id:guid}/match")]
    public async Task<ActionResult<ContractResponse>> MatchAsync(ContractRequest request, Guid id)
    {
        var response = await _contractsService.MatchAsync(request, id);
        return response == null ? NotFound() : Ok(response);
    }

    [HttpPut("{id:guid}/contract")]
    public async Task<ActionResult<ContractResponse>> ContractAsync(Guid id)
    {
        var response = await _contractsService.ContractAsync(id);
        return response == null ? NotFound() : Ok(response);
    }

    [HttpPut("{id:guid}/fulfill")]
    public async Task<ActionResult<ContractResponse>> FulfillAsync(ContractRequest request, Guid id)
    {
        var response = await _contractsService.FulfillAsync(request, id);
        return response == null ? NotFound() : Ok(response);
    }

    [HttpGet("client/{clientId:guid}")]
    public async Task<ActionResult<ContractsResponse>> GetClientContractsAsync(Guid clientId)
    {
        return Ok(await _contractsService.GetClientContractsAsync(clientId));
    }
}
