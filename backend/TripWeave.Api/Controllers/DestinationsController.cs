using Microsoft.AspNetCore.Mvc;

namespace TripWeave.Api.Controllers;

[ApiController]
[Route("api/destinations")]
public class DestinationsController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetDestination(int id)
    {
        if (id == 1)
        {
            return Ok(new
            {
                Id = 1,
                Name = "Ella",
                Country = "Sri Lanka"
            });
        }

        return NotFound(new
        {
            Message = "Destination not found"
        });
    }
}
