using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Freelancers;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly IFreelancersService _freelancersService;

    public FreelancersController(IFreelancersService freelancersService)
    {
        _freelancersService = freelancersService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FreelancerResponse>> GetFreelancerAsync(Guid id)
    {
        return Ok(await _freelancersService.GetFreelancerAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<FreelancersResponse>> GetFreelancersAsync([FromQuery] FreelancerQuery query)
    {
        return Ok(await _freelancersService.GetFreelancersAsync(query));
    }
}
