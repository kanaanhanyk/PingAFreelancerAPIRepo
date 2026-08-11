using Microsoft.AspNetCore.Mvc;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiControler]
[Route("api/[controller]")]
public class FreelancersController : ControllerBase
{
    private readonly IFreelancersService _freelancersService;

    public FreelancersControler(IFreelancersService freelansersService)
    {
        _freelancersService = freelancersService;

    }

    [HttpGet]
    public async Task<ActionResult<FreelancersResponse>> GetFreelanceersAsync()
    {
        var freelancers = await _freelandersService.GetFreelancersAsync();
        return Ok(freelancers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FreelancerResponse>> GetFreelancerAsync(int id)
    {
        var freelancer = await _freelancersService.GetFreelancerAsync(id);
        return Ok(freelancer);
    }
}