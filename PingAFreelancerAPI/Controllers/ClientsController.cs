using Microsoft.AspNetCore.Mvc;
using PingAFreelancerApplication.Clients;
using PingAFreelancerContracts;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
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
        var response = await _clientsService.CreateClientAsync(clientRequest);
        return CreatedAtAction(nameof(GetClientAsync), new { id = response.Id }, response);
    }
}
