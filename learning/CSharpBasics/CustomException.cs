class InvalidTripStateException : Exception
{
    public InvalidTripStateException(string message) : base(message)
    {
    }
}

class InsufficientTripBudgetException : Exception
{
    public InsufficientTripBudgetException(string message) : base(message)
    {
    }
}
