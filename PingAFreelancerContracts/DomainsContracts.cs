namespace PingAFreelancerContracts;

public sealed record DomainResponse(
    string Name,
    string PhotoPath,
    FreelancersResponse Freelancers,
    ExpertisesResponse Expertises
);

public sealed record DomainsResponse(
    List<DomainResponse> Items
);