using System.Threading.Tasks;

namespace BlazorDesktopWeather
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherAsync(string location);
    }
}
