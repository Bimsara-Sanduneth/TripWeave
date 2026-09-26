using TripWeave.Api.Models;
using TripWeave.Api.DTOs;

namespace TripWeave.Api.Interfaces;

public interface ITripService{
    List<Trip> GetAllTrips();
    Trip? GetTripById(int id);
    Trip CreateTrip(Trip trip);
    bool UpdateTrip(int id, Trip updatedTrip);
    bool PatchTrip(int id, PatchTripDto dto);
    bool DeleteTrip(int id);
}
