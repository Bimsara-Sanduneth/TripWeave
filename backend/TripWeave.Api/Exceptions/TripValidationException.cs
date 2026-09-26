namespace TripWeave.Api.Exceptions;

public class TripValidationException : Exception
{
    public TripValidationException(string message) : base(message)
    {
    }
}
