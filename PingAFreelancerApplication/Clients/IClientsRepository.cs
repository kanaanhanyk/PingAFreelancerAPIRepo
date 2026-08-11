using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Clients;

public interface IClientsRepository
{
    Task<Client> GetClientAsync(Guid id);
    Task<List<Client>> GetClientsAsync();
}
