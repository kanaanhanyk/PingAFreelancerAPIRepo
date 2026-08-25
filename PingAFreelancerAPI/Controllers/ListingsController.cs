using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ListingsController : ControllerBase
{
    [HttpGet("mine")]
    public IActionResult GetMine()
    {
        var oid = User.GetObjectId();
        var tid = User.GetTenantId();
        return Ok(new { userId = oid, tenantId = tid });
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(string id) => NoContent();
}