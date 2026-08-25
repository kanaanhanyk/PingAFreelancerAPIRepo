namespace PingAFreelancerApplication.Users;

public interface ICurrentUser
{
    string? ObjectId { get; }
    string? TenantId { get; }
    bool IsAuthenticated { get; }
}