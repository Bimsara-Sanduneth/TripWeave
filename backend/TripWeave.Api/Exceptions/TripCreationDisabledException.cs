namespace TripWeave.Api.Exceptions;

public class TripCreationDisabledException : Exception
{
    public TripCreationDisabledException(string message) : base(message)
    {
    }
}
