class Trip
{
    public string Destination { get; set; }
    public string? Notes { get; set; }
    public int? Rating { get; set; }
    public decimal? ActualCost { get; set; }
    public int Days { get; private set; }
    public decimal Budget { get; private set; }
    public int Travelers { get; private set; }
    public decimal PlannedCost { get; private set; }
    public TripStatus Status { get; private set; } = TripStatus.Planning;

    public void Confirm()
    {
        if (Status != TripStatus.Planning)
        {
            throw new InvalidTripStateException($"Cannot confirm a trip with status {Status}.");
        }
        Status = TripStatus.Confirmed;
    }

    public void Complete()
    {
        if (Status != TripStatus.Confirmed)
        {
            throw new InvalidTripStateException($"Cannot complete a trip with status {Status}.");
        }
        Status = TripStatus.Completed;
    }

    public void Cancel()
    {
        if (Status != TripStatus.Planning && Status != TripStatus.Confirmed)
        {
            throw new InvalidTripStateException($"Cannot cancel a trip with status {Status}.");
        }
        Status = TripStatus.Cancelled;
    }

    public void DisplayStatusMessage()
    {
        switch (Status)
        {
            case TripStatus.Planning:
                Console.WriteLine("Your trip is being planned.");
                break;
            case TripStatus.Confirmed:
                Console.WriteLine("Your trip is confirmed. Get ready to travel!");
                break;
            case TripStatus.Completed:
                Console.WriteLine("Your trip is complete. We hope you enjoyed it!");
                break;
            case TripStatus.Cancelled:
                Console.WriteLine("Your trip has been cancelled.");
                break;
        }
    }

    public Trip(string destination, int days, decimal budget, int travelers = 1)
    {
        Destination = destination;
        SetDays(days);
        SetBudget(budget);
        SetTravelers(travelers);
    }
    public void SetBudget(decimal budget)
    {
        if (budget < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(budget), budget, "Budget cannot be negative.");
        }
        Budget = budget;
    }

    public void SetTravelers(int travelers)
    {
        if (travelers < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(travelers), travelers, "Travelers must be at least 1.");
        }
        Travelers = travelers;
    }

    public void SetDays(int days)
    {
        if (days < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(days), days, "Days must be at least 1.");
        }
        Days = days;
    }

    public void SetPlannedCost(decimal plannedCost)
    {
        if (plannedCost < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(plannedCost), plannedCost, "Planned cost cannot be negative.");
        }
        PlannedCost = plannedCost;
    }

    public void ConfirmTrip()
    {
        if (PlannedCost > Budget)
        {
            throw new InsufficientTripBudgetException(
                $"Planned cost of Rs. {PlannedCost:N2} exceeds the budget of Rs. {Budget:N2}.");
        }
    }
}
