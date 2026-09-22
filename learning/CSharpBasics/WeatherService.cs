class WeatherService : IWeatherService
{
    public async Task<string> GetWeatherAsync()
    {
        await Task.Delay(1000);
        return "24°C - Cloudy";
    }
}
