using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Clients;
using PingAFreelancerContracts;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly PingAFreelancerContext _context;

    public ClientsRepository(PingAFreelancerContext context)
    {
        _context = context;
    }

    public async Task<Client> GetClientAsync(Guid id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> CreateClientAsync(ClientRequest client)
    {
        var newClient = new Client
        {
            FirstName = client.FirstName,
            LastName = client.LastName,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
            AvatarColor = client.AvatarColor,
            DateRegistered = DateTimeOffset.UtcNow,
            LastActive = DateTimeOffset.UtcNow,
        };

        _context.Clients.Add(newClient);
        await _context.SaveChangesAsync();

        return newClient;
    }
}
