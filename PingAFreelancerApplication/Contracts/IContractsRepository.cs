using PingAFreelancerCore.Entities;

namespace PingAFreelancerApplication.Contracts;

public interface IContractsRepository
{
    Task<Contract> GetContractAsync(Guid id);
    Task<List<Contract>> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus);
    Task<Contract> CreateContractAsync(PingAFreelancerContracts.ContractRequest contract);
}
