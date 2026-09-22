using Microsoft.AspNetCore.Mvc;

namespace TripWeave.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        return Ok(new
        {
            Status = "Healthy",
            Application = "TripWeave API"
        });
    }
}