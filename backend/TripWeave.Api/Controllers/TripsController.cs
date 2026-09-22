using Microsoft.AspNetCore.Mvc;
using TripWeave.Api.Models;

namespace TripWeave.Api.Controllers;

[ApiController]
[Route("api/trips")]
public class TripsController : ControllerBase
{
    private static readonly List<Trip> Trips = new()
    {
        new Trip
        {
            Id = 1,
            Destination = "Ella",
            Days = 5,
            Budget = 50000
        },
        new Trip
        {
            Id = 2,
            Destination = "Kandy",
            Days = 3,
            Budget = 30000
        },
        new Trip
        {
            Id = 3,
            Destination = "Galle",
            Days = 4,
            Budget = 40000
        }
    };

    [HttpGet]
    public ActionResult<List<Trip>> GetAllTrips()
    {
        return Ok(Trips);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Trip> GetTripById(int id)
    {
        Trip? trip = Trips.FirstOrDefault(t => t.Id == id);

        if (trip is null)
        {
            return NotFound();
        }

        return Ok(trip);
    }
}
