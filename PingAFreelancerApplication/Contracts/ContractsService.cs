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

    public async Task<ContractResponse> PingAsync(ContractRequest request)
    {
        var contract = await _contractsRepository.PingAsync(request);
        return contract.MapToContractResponse();
    }

    public async Task<ContractResponse?> MatchAsync(ContractRequest request, Guid id)
    {
        var contract = await _contractsRepository.MatchAsync(request, id);
        return contract?.MapToContractResponse();
    }

    public async Task<ContractResponse?> ContractAsync(Guid id)
    {
        var contract = await _contractsRepository.ContractAsync(id);
        return contract?.MapToContractResponse();
    }

    public async Task<ContractResponse?> FulfillAsync(ContractRequest request, Guid id)
    {
        var contract = await _contractsRepository.FulfillAsync(request, id);
        return contract?.MapToContractResponse();
    }
}
