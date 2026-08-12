using PingAFreelancerCore.Entities;
using PingAFreelancerInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PingAFreelancerApplication.Contracts;
using PingAFreelancerContracts;

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

    public async Task<List<Contract>> GetContractsAsync(Guid freelancerId, Guid clientId, PingAFreelancerCore.Entities.ContractStatus contractStatus)
    {
        return await _context.Contracts
            .Where(c => c.FreelancerId == freelancerId && c.ClientId == clientId && c.Status == contractStatus)
            .ToListAsync();
    }

    public async Task<Contract> CreateContractAsync(ContractRequest contract)
    {
        var newContract = new Contract
        {
            ClientId = contract.ClientId,
            FreelancerId = contract.FreelancerId,
            Rating = contract.Rating,
            HoursContracted = contract.HoursContracted,
            AmountPaid = contract.AmountPaid,
            DatePinged = contract.DatePinged,
            DateMatched = contract.DateMatched,
            DateContracted = contract.DateContracted,
            DateFulfilled = contract.DateFulfilled,
            ProposalMessage = contract.ProposalMessage,
            Review = contract.Review,
            Status = (PingAFreelancerCore.Entities.ContractStatus)(int)contract.Status,
        };
        _context.Add(newContract);
        await _context.SaveChangesAsync();

        return newContract;
    }
}
