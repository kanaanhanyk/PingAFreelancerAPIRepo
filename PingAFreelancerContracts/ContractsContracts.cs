namespace PingAFreelancerContracts;

public enum ContractStatus
{
    Pinged,
    Matched,
    Contracted,
    Fulfilled
}

public sealed record ContractResponse(
    Guid Id,
    Guid ClientId,
    Guid FreelancerId,
    int? Rating,
    int? HoursContracted,
    decimal? AmountPaid,
    DateTimeOffset DatePinged,
    DateTimeOffset? DateMatched,
    DateTimeOffset? DateContracted,
    DateTimeOffset? DateFulfilled,
    string? ProposalMessage,
    string? Review,
    ContractStatus Status
);

public sealed record ContractsResponse(
    List<ContractResponse> Items
);
