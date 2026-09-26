using Microsoft.AspNetCore.Mvc;
using TripWeave.Api.DTOs;
using TripWeave.Api.Models;
using TripWeave.Api.Interfaces;

namespace TripWeave.Api.Controllers;

[ApiController]
[Route("api/trips")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public ActionResult<List<Trip>> GetAllTrips()
    {
        var trips = _tripService.GetAllTrips();

        return Ok(trips);
    }

    [HttpPost]
    public ActionResult<Trip> CreateTrip([FromBody] CreateTripDto request)
    {
        Trip trip = new Trip
        {
            Destination = request.Destination,
            Days = request.Days,
            Budget = request.Budget
        };

        var createdTrip = _tripService.CreateTrip(trip);

        return CreatedAtAction(
            nameof(GetTripById),
            new { id = createdTrip.Id },
            createdTrip
        );
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateTrip(
        int id,
        [FromBody] UpdateTripDto request)
    {
        var updatedTrip = new Trip
        {
            Destination = request.Destination,
            Days = request.Days,
            Budget = request.Budget
        };

        bool updated = _tripService.UpdateTrip(id, updatedTrip);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteTrip(int id)
    {
        bool deleted = _tripService.DeleteTrip(id);

        if (!deleted)
        {
            return NotFound();
        }

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

}
