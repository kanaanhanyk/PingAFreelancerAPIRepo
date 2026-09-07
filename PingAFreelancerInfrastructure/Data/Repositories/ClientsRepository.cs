using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Clients;
using PingAFreelancerContracts;
using PingAFreelancerApplication.Users;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class ClientsRepository : IClientsRepository
{
    private readonly PingAFreelancerContext _context;

    public ClientsRepository(PingAFreelancerContext context, ICurrentUser currentUser)
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

    public async Task<(Client, bool)> CreateClientAsync(ClientRequest client, Guid oidGuid)
    {
        var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.Id == oidGuid);
        if (existingClient is not null) return (existingClient, false);

        var newClient = new Client
        {
            Id = oidGuid,
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
        return (newClient, true);
    }
}
