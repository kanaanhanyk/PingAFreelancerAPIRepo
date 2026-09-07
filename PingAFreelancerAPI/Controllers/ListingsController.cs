using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using PingAFreelancerApplication;
using PingAFreelancerApplication.Users;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ListingsController : ControllerBase
{
    private readonly ICurrentUser _currentUser;

    public ListingsController(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    [HttpGet("mine")]
    public IActionResult GetMine()
    {
        var userId = _currentUser.ObjectId;
        var tenantId = _currentUser.TenantId;
        return Ok(new { userId, tenantId });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(string id) => NoContent();
}