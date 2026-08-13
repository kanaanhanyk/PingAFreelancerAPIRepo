using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Contracts;

public interface IContractsService
{
    Task<ContractResponse> GetContractAsync(Guid id);
    Task<ContractsResponse> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus);
    Task<ContractResponse> PingAsync(ContractRequest request);
    Task<ContractResponse?> MatchAsync(ContractRequest request, Guid id);
    Task<ContractResponse?> ContractAsync(Guid id);
    Task<ContractResponse?> FulfillAsync(ContractRequest request, Guid id);
}
