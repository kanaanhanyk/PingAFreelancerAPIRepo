namespace PingAFreelancerContracts;

public sealed record ExpertiseResponse(
    int Id, int DomainId, string Name, string PhotoPath);

public sealed record ExpertisesResponse(
    List<ExpertiseResponse> Expertises
);

