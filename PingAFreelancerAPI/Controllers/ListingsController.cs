using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

namespace PingAFreelancerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RequiredScope("access_as_user")]
public class ListingsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMine()
    {
        var oid = User.GetObjectId();
        return Ok(new { userId = oid });
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(string id) => NoContent();
}