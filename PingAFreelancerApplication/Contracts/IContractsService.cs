using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Contracts;

public interface IContractsService
{
    Task<ContractResponse> GetContractAsync(Guid id);
    Task<ContractsResponse> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus);
}
