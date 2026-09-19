readonly struct Percentage
{
    public double Value { get; }

    public Percentage(double value)
    {
        if (double.IsNaN(value) || value < 0 || value > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value,
                "Percentage must be between 0 and 100 inclusive.");
        }

        Value = value;
    }
}
