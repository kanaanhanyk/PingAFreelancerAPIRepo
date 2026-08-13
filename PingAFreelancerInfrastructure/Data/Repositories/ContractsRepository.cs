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

    public async Task<Contract> PingAsync(ContractRequest contract)
    {
        var newContract = new Contract
        {
            ClientId = contract.ClientId,
            FreelancerId = contract.FreelancerId,
            Rating = null,
            HoursContracted = null,
            AmountPaid = null,
            DatePinged = DateTimeOffset.UtcNow,
            DateMatched = null,
            DateContracted = null,
            DateFulfilled = null,
            ProposalMessage = null,
            Review = null,
            Status = PingAFreelancerCore.Entities.ContractStatus.Pinged,
        };
        _context.Contracts.Add(newContract);
        await _context.SaveChangesAsync();

        return newContract;
    }

    public async Task<Contract?> MatchAsync(ContractRequest contract, Guid id)
    {
        var existingContract = await _context.Contracts.FindAsync(id);
        if (existingContract == null) return null;

        existingContract.DateMatched = DateTimeOffset.UtcNow;
        existingContract.ProposalMessage = contract.ProposalMessage;
        existingContract.Status = PingAFreelancerCore.Entities.ContractStatus.Matched;
        await _context.SaveChangesAsync();

        return existingContract;
    }

    public async Task<Contract?> ContractAsync(Guid id)
    {
        var existingContract = await _context.Contracts.FindAsync(id);
        if (existingContract == null) return null;

        existingContract.DateContracted = DateTimeOffset.UtcNow;
        existingContract.Status = PingAFreelancerCore.Entities.ContractStatus.Contracted;
        await _context.SaveChangesAsync();

        return existingContract;
    }

    public async Task<Contract?> FulfillAsync(ContractRequest contract, Guid id)
    {
        var existingContract = await _context.Contracts.FindAsync(id);
        if (existingContract == null) return null;

        existingContract.Rating = contract.Rating;
        existingContract.HoursContracted = contract.HoursContracted;
        existingContract.AmountPaid = contract.AmountPaid;
        existingContract.DateFulfilled = DateTimeOffset.UtcNow;
        existingContract.Review = contract.Review;
        existingContract.Status = PingAFreelancerCore.Entities.ContractStatus.Fulfilled;

        await _context.SaveChangesAsync();

        return existingContract;
    }
}
