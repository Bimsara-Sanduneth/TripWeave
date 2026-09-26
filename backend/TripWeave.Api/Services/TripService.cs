using TripWeave.Api.Interfaces;
using TripWeave.Api.Models;
using TripWeave.Api.DTOs;
using Microsoft.Extensions.Options;
using TripWeave.Api.Configuration;

namespace TripWeave.Api.Services;

public class TripService : ITripService{
    private readonly List<Trip> _trips = new();
    private int _nextId = 1;
    private readonly TripSettings _settings;
    private readonly ILogger<TripService> _logger;

    public TripService(
        IOptions<TripSettings> options,
        ILogger<TripService> logger){
        _settings = options.Value;
        _logger = logger;
    }

    public List<Trip> GetAllTrips(){
        return _trips.ToList();
    }

    public Trip? GetTripById(int id){
        return _trips.FirstOrDefault(t => t.Id == id);
    }

    public Trip CreateTrip(Trip trip){
        if (!_settings.EnableTripCreation){
            _logger.LogWarning(
                "Trip creation rejected because the feature is disabled");

            throw new InvalidOperationException(
                "Trip creation is currently disabled.");
        }

        if (trip.Days > _settings.MaxDays){
            _logger.LogWarning(
                "Trip creation rejected. Requested days: {RequestedDays}, maximum: {MaxDays}",
                trip.Days,
                _settings.MaxDays);

            throw new ArgumentOutOfRangeException(
                nameof(trip.Days),
                $"Trip duration cannot exceed {_settings.MaxDays} days.");
        }

        if (trip.Budget > _settings.MaxBudget){
            _logger.LogWarning(
                "Trip creation rejected. Requested budget: {RequestedBudget}, maximum: {MaxBudget}",
                trip.Budget,
                _settings.MaxBudget);

            throw new ArgumentOutOfRangeException(
                nameof(trip.Budget),
                $"Trip budget cannot exceed {_settings.MaxBudget}.");
        }

        trip.Id = _nextId++;
        _trips.Add(trip);
        _logger.LogInformation(
            "Trip {TripId} created successfully",
            trip.Id);
        return trip;
    }

    public bool UpdateTrip(int id, Trip updatedTrip){
        Trip? trip = _trips.FirstOrDefault(t => t.Id == id);

        if (trip is null){
            return false;
        }

        trip.Destination = updatedTrip.Destination;
        trip.Days = updatedTrip.Days;
        trip.Budget = updatedTrip.Budget;
        return true;
    }

    public bool PatchTrip(int id, PatchTripDto dto){
        Trip? trip = _trips.FirstOrDefault(t => t.Id == id);

        if (trip is null){
            return false;
        }

        if (dto.Destination is not null){
            trip.Destination = dto.Destination;
        }

        if (dto.Days.HasValue){
            trip.Days = dto.Days.Value;
        }

        if (dto.Budget.HasValue){
            trip.Budget = dto.Budget.Value;
        }

        return true;
    }

    public bool DeleteTrip(int id){
        Trip? trip = _trips.FirstOrDefault(t => t.Id == id);

        if (trip is null){
            _logger.LogWarning(
                "Trip deletion rejected. Trip {TripId} was not found",
                id);
            return false;
        }

        _trips.Remove(trip);
        _logger.LogInformation(
            "Trip {TripId} deleted successfully",
            id);
        return true;
    }
}
