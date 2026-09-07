using PingAFreelancerContracts;
using PingAFreelancerApplication.Users;

namespace PingAFreelancerApplication.Clients;

public class ClientsService : IClientsService
{
    private readonly IClientsRepository _clientsRepository;
    private readonly ICurrentUser _currentUser;

    public ClientsService(IClientsRepository clientsRepository, ICurrentUser currentUser)
    {
        _clientsRepository = clientsRepository;
        _currentUser = currentUser;
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

    public async Task<(ClientResponse, bool)> CreateClientAsync(ClientRequest clientRequest)
    {
        var oid = _currentUser.ObjectId;

        if (!Guid.TryParse(oid, out var objectId))
        {
            Console.Error.WriteLine(oid);
            Console.Error.WriteLine(objectId);
            throw new ArgumentException("Invalid ObjectId", nameof(oid));
        }

        var (client, created) = await _clientsRepository.CreateClientAsync(clientRequest, objectId);
        return (client.MapToClientResponse(), created);
    }
}
