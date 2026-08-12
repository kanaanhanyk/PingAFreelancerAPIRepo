using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Clients;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IClientsRepository clientsRepository)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task<ClientResponse> GetClientAsync(Guid id)
    {
        var client = await _clientsRepository.GetClientAsync(id);
        return client.MapToClientResponse();
    }

    public async Task<ClientsResponse> GetClientsAsync()
    {
        var clients = await _clientsRepository.GetClientsAsync();
        return clients.MapToClientsResponse();
    }

    public async Task<ClientResponse> CreateClientAsync(ClientRequest clientRequest)
    {
        var client = await _clientsRepository.CreateClientAsync(clientRequest);
        return client.MapToClientResponse();
    }
}
