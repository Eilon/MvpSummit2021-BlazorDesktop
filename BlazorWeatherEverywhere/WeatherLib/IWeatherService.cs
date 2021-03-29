using System.Threading.Tasks;

namespace WeatherLib
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherAsync(string location);
    }
}
