using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Clients;

public interface IClientsService
{
    Task<ClientResponse> GetClientAsync(Guid id);
    Task<ClientsResponse> GetClientsAsync();
    Task<ClientResponse> CreateClientAsync(ClientRequest client);
}
