using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Contracts;

namespace PingAFreelancerInfrastructure.Data.Repositories;

public class ContractsRepository : IContractsRepository
{
    private readonly PingAFreelancerContext _context;

    public ContractsRepository(PingAFreelancerContext context)
    {
        _context = context;
    }

    public async Task<Contract> GetContractAsync(Guid id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task<List<Contract>> GetContractsAsync()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<List<Contract>> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus)
    {
        return await _context.Contracts
            .Where(c => c.FreelancerId == freelancerId && c.ClientId == clientId && c.Status == contractStatus)
            .ToListAsync();
    }
}
