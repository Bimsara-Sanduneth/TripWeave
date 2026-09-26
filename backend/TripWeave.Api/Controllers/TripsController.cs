using Microsoft.AspNetCore.Mvc;
using TripWeave.Api.DTOs;
using TripWeave.Api.Models;
using TripWeave.Api.Interfaces;
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
        var trips = _tripService.GetAllTrips();

        return Ok(trips);
    }

    [HttpPost]
    public ActionResult<Trip> CreateTrip([FromBody] CreateTripDto request)
    {
        int newId = Trips.Count == 0
            ? 1
            : Trips.Max(t => t.Id) + 1;

        Trip trip = new Trip
        {
            Id = newId,
            Destination = request.Destination,
            Days = request.Days,
            Budget = request.Budget
        };

        Trips.Add(trip);

        return CreatedAtAction(
            nameof(GetTripById),
            new { id = trip.Id },
            trip
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateTrip(
        int id,
        [FromBody] UpdateTripDto request)
    {
        Trip? trip = Trips.FirstOrDefault(t => t.Id == id);

        if (trip is null)
        {
            return NotFound();
        }

        trip.Destination = request.Destination;
        trip.Days = request.Days;
        trip.Budget = request.Budget;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteTrip(int id)
    {
        Trip? trip = Trips.FirstOrDefault(t => t.Id == id);

        if (trip is null)
        {
            return NotFound();
        }

        Trips.Remove(trip);

        return NoContent();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Trip> GetTripById(int id)
    {
        Trip? trip = _tripService.GetTripById(id);

        if (trip is null)
        {
            return NotFound();
        }

        return Ok(trip);
    }

    
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

}
