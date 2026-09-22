class TripPlanner
{
    private readonly IWeatherService _weatherService;

    public TripPlanner(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task ShowWeatherAsync()
    {
        Console.WriteLine("Fetching trip weather...");
        string weather = await _weatherService.GetWeatherAsync();
        Console.WriteLine($"Weather: {weather}");
    }
}
