using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Clients;

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
}
