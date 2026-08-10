namespace PingAFreelancerContracts;

public sealed record FreelancerResponse(
    Guid Id,
    string FirstName,
    string? LastName,
    string Email,
    string? PhoneNumber,
    int DomainId,
    int ExpertiseId,
    decimal HourlyRate,
    int HoursBilled,
    decimal TotalEarned,
    int InteractionCount,
    int RatingSum,
    DateTimeOffset DateRegistered,
    string PhotoPath,
    string AvatarColor,
    DateTimeOffset? LastActive,
    double Latitude,
    double Longitude
);

public sealed record FreelancersResponse(
    List<FreelancerResponse> Items
);
