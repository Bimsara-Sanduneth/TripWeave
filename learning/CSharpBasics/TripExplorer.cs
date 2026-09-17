using System.Globalization;

static class TripExplorer
{
    public static void Run(List<Trip> trips)
    {
        while (true)
        {
            DisplayMenu();
            string? input = Console.ReadLine();
            if (input == null) return;

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Please enter a number from 1 to 7.");
                continue;
            }

            Console.WriteLine();
            switch (choice)
            {
                case 1: DisplayAllTrips(trips); break;
                case 2: DisplayAffordableTrips(trips); break;
                case 3: SearchTrip(trips); break;
                case 4: DisplayTripsByBudget(trips); break;
                case 5: DisplayStatistics(trips); break;
                case 6:
                    Console.WriteLine("Exiting the program.");
                    return;
                case 7: AdvancedFilter(trips); break;
                default:
                    Console.WriteLine("Invalid option. Choose a number from 1 to 7.");
                    break;
            }
            Console.WriteLine();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("================================");
        Console.WriteLine("    TripWeave Trip Explorer");
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine("1. Show all trips");
        Console.WriteLine("2. Show affordable trips");
        Console.WriteLine("3. Search destination");
        Console.WriteLine("4. Sort by budget");
        Console.WriteLine("5. Show trip statistics");
        Console.WriteLine("6. Exit");
        Console.WriteLine("7. Advanced Filter");
        Console.WriteLine();
        Console.WriteLine("Choose an option:");
    }

    private static string Money(decimal amount) =>
        amount.ToString("N2", CultureInfo.InvariantCulture);

    private static void DisplayTrip(Trip trip)
    {
        Console.WriteLine($"{trip.Destination} - {trip.Days} days - Rs. {Money(trip.Budget)}");
    }

    private static void DisplayTrips(IEnumerable<Trip> trips)
    {
        bool found = false;
        foreach (Trip trip in trips)
        {
            DisplayTrip(trip);
            found = true;
        }
        if (!found) Console.WriteLine("No matching trips.");
    }

    private static void DisplayAllTrips(List<Trip> trips)
    {
        Console.WriteLine("===== All Trips =====");
        DisplayTrips(trips);
    }

    private static void DisplayAffordableTrips(List<Trip> trips)
    {
        Console.WriteLine("===== Affordable Trips =====");
        DisplayTrips(trips.Where(trip => trip.Budget <= 200000)
            .OrderBy(trip => trip.Budget));
    }

    private static void SearchTrip(List<Trip> trips)
    {
        Console.WriteLine("Enter destination:");
        string? destination = Console.ReadLine()?.Trim();
        var trip = trips.FirstOrDefault(trip =>
            trip.Destination.Equals(destination, StringComparison.OrdinalIgnoreCase));
        if (trip == null) Console.WriteLine("Trip not found.");
        else DisplayTrip(trip);
    }

    private static void DisplayTripsByBudget(List<Trip> trips)
    {
        Console.WriteLine("===== Trips Sorted by Budget =====");
        Console.WriteLine("Budget: Low → High");
        DisplayTrips(trips.OrderBy(trip => trip.Budget));
    }

    private static void DisplayStatistics(List<Trip> trips)
    {
        Console.WriteLine("===== Statistics =====");
        Console.WriteLine();
        Console.WriteLine($"Total Trips: {trips.Count}");
        if (trips.Count == 0) return;
        Console.WriteLine($"Total Budget: Rs. {Money(trips.Sum(trip => trip.Budget))}");
        Console.WriteLine($"Average Budget: Rs. {Money(trips.Average(trip => trip.Budget))}");
        Console.WriteLine($"Minimum Budget: Rs. {Money(trips.Min(trip => trip.Budget))}");
        Console.WriteLine($"Maximum Budget: Rs. {Money(trips.Max(trip => trip.Budget))}");
    }

    private static void AdvancedFilter(List<Trip> trips)
    {
        decimal maximumBudget;
        while (true)
        {
            Console.WriteLine("Maximum budget:");
            string? input = Console.ReadLine();
            if (input == null) return;
            if (decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture,
                out maximumBudget) && maximumBudget >= 0) break;
            Console.WriteLine("Enter a valid budget of zero or more (for example, 150000).");
        }

        int minimumDays;
        while (true)
        {
            Console.WriteLine("Minimum days:");
            string? input = Console.ReadLine();
            if (input == null) return;
            if (int.TryParse(input, out minimumDays) && minimumDays >= 1) break;
            Console.WriteLine("Enter a whole number of days of at least 1.");
        }

        Console.WriteLine("===== Matching Trips =====");
        DisplayTrips(trips
            .Where(trip => trip.Budget <= maximumBudget && trip.Days >= minimumDays)
            .OrderBy(trip => trip.Budget));
    }
}
