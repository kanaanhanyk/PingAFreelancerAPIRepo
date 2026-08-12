using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Contracts;

public class ContractsService : IContractsService
{
    private readonly IContractsRepository _contractsRepository;

    public ContractsService(IContractsRepository contractsRepository)
    {
        _contractsRepository = contractsRepository;
    }

    public async Task<ContractResponse> GetContractAsync(Guid id)
    {
        var contract = await _contractsRepository.GetContractAsync(id);
        return contract.MapToContractResponse();
    }

    public async Task<ContractsResponse> GetContractsAsync(Guid freelancerId, Guid clientId, ContractStatus contractStatus)
    {
        var coreStatus = (PingAFreelancerCore.Entities.ContractStatus)(int)contractStatus;
        var contracts = await _contractsRepository.GetContractsAsync(freelancerId, clientId, coreStatus);
        return contracts.MapToContractsResponse();
    }

    public async Task<ContractResponse> CreateContractAsync(ContractRequest request)
    {
        var contract = await _contractsRepository.CreateContractAsync(request);
        return contract.MapToContractResponse();
    }
}
