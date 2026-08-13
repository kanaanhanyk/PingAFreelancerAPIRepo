using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Contracts;

public interface IContractsRepository
{
    Task<Contract> GetContractAsync(Guid id);
    Task<List<Contract>> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus);
    Task<Contract> PingAsync(PingAFreelancerContracts.ContractRequest contract);
    Task<Contract?> MatchAsync(PingAFreelancerContracts.ContractRequest contract, Guid id);
    Task<Contract?> ContractAsync(Guid id);
    Task<Contract?> FulfillAsync(PingAFreelancerContracts.ContractRequest contract, Guid id);
}
