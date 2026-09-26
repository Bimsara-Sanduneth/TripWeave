using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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

    [HttpPatch("{id:int}")]
    public IActionResult PatchTrip(int id, [FromBody] JsonElement json)
    {
        if (json.ValueKind != JsonValueKind.Object)
        {
            return BadRequest("Expected a JSON object.");
        }

        if (!json.EnumerateObject().Any())
        {
            return BadRequest("Provide at least one property.");
        }

        var allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "destination",
            "days",
            "budget"
        };

        foreach (var property in json.EnumerateObject())
        {
            if (!allowed.Contains(property.Name))
            {
                return BadRequest($"Unknown property: {property.Name}.");
            }

            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return BadRequest($"{property.Name} cannot be null.");
            }
        }

        PatchTripDto? dto;

        try
        {
            dto = json.Deserialize<PatchTripDto>(
                new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }
        catch (JsonException)
        {
            return BadRequest("Invalid property value.");
        }

        if (dto is null)
        {
            return BadRequest("Invalid request.");
        }

        var results = new List<ValidationResult>();
        var context = new ValidationContext(dto);

        bool isValid = Validator.TryValidateObject(
            dto, context, results, validateAllProperties: true);

        if (!isValid)
        {
            return BadRequest(results.Select(result => result.ErrorMessage));
        }

        bool updated = _tripService.PatchTrip(id, dto);

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
