using TripWeave.Api.Interfaces;
using TripWeave.Api.Models;

namespace TripWeave.Api.Services;

public class TripService : ITripService{
    private readonly List<Trip> _trips = new();
    private int _nextId = 1;

    public List<Trip> GetAllTrips(){
        return _trips.ToList();
    }

    public Trip? GetTripById(int id){
        return _trips.FirstOrDefault(t => t.Id == id);
    }

    public Trip CreateTrip(Trip trip){
        trip.Id = _nextId++;
        _trips.Add(trip);
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

    public bool DeleteTrip(int id){
        Trip? trip = _trips.FirstOrDefault(t => t.Id == id);

        if (trip is null){
            return false;
        }

        _trips.Remove(trip);
        return true;
    }
}
