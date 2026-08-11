using PingAFreelancerCore.Entities;
using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Contracts;

public static class ContractMappings
{
    public static ContractResponse MapToContractResponse(this Contract contract)
    {
        return new ContractResponse(
            contract.Id,
            contract.ClientId,
            contract.FreelancerId,
            contract.Rating,
            contract.HoursContracted,
            contract.AmountPaid,
            contract.DatePinged,
            contract.DateMatched,
            contract.DateContracted,
            contract.DateFulfilled,
            contract.ProposalMessage,
            contract.Review,
            (PingAFreelancerContracts.ContractStatus)(int)contract.Status
        );
    }

    public static ContractsResponse MapToContractsResponse(this List<Contract> contracts)
    {
        return new ContractsResponse(
            contracts.Select(c => c.MapToContractResponse()).ToList()
        );
    }
}
