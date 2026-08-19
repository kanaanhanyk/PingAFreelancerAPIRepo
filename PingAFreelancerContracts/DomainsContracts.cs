namespace PingAFreelancerContracts;

public sealed record DomainResponse(
    int Id,
    string Name,
    string PhotoPath
);

public sealed record DomainsResponse(
    List<DomainResponse> Items
);