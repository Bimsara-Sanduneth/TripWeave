using TripWeave.Api.Models;

namespace TripWeave.Api.Interfaces;

public interface ITripService{
    List<Trip> GetAllTrips();
    Trip? GetTripById(int id);
    Trip CreateTrip(Trip trip);
    bool DeleteTrip(int id);
}