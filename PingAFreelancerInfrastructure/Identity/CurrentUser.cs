using Microsoft.AspNetCore.Http;
using PingAFreelancerApplication.Users;
using System.Security.Claims;

namespace PingAFreelancerInfrastructure.Identity
{
    public sealed class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal? claimsPrincipal => _httpContextAccessor.HttpContext?.User;

        public string? ObjectId => claimsPrincipal?.FindFirstValue("oid");
        public string? TenantId => claimsPrincipal?.FindFirstValue("tid");
        public bool IsAuthenticated => claimsPrincipal?.Identity?.IsAuthenticated ?? false;
    }
}