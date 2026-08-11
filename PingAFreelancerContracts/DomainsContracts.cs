namespace PingAFreelancerContracts;

public sealed record DomainResponse(
    string Name,
    string PhotoPath
);

public sealed record DomainsResponse(
    List<DomainResponse> Items
);