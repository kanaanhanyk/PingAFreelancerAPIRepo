using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Clients;
using PingAFreelancerContracts;
using Microsoft.AspNetCore.Authorization;


namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientResponse>> GetClientAsync(Guid id)
    {
        return Ok(await _clientsService.GetClientAsync(id));
    }

    [HttpGet]
    public async Task<ActionResult<ClientsResponse>> GetClientsAsync()
    {
        return Ok(await _clientsService.GetClientsAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ClientResponse>> CreateClientAsync(ClientRequest clientRequest)
    {
        var (response, created) = await _clientsService.CreateClientAsync(clientRequest);
        if (created)
        {
            return CreatedAtAction(nameof(GetClientAsync), new { id = response.Id }, response);
        }
        return Ok(response);
    }
}
