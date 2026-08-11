namespace PingAFreelancerContracts;

public sealed record ClientResponse(
    Guid Id,
    string FirstName,
    string? LastName,
    string Email,
    string? PhoneNumber,
    DateTimeOffset DateRegistered,
    decimal TotalSpent,
    int HoursBilled,
    int InteractionCount,
    decimal RatingSum,
    DateTimeOffset? LastActive,
    string AvatarColor
);

public sealed record ClientsResponse(
    List<ClientResponse> Items
);
