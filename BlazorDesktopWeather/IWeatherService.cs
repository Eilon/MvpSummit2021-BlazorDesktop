using System.Threading.Tasks;

namespace BlazorDesktopWeather
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string location);
    }
}
