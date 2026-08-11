using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Expertises;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpertisesController : ControllerBase
{
    private readonly IExpertisesService _expertisesService;

    public ExpertisesController(IExpertisesService expertisesService)
    {
        _expertisesService = expertisesService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpertiseResponse>> GetExpertiseAsync(int id)
    {
        return Ok(await _expertisesService.GetExpertiseAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<ExpertisesResponse>> GetExpertisesAsync()
    {
        return Ok(await _expertisesService.GetExpertisesAsync());
    }
}
