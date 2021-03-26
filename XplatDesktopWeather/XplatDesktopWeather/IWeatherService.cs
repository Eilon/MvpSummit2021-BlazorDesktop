using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherAsync(string location);
    }
}
