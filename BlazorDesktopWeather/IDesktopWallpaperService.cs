using System.Threading.Tasks;

namespace BlazorDesktopWeather
{
    public interface IDesktopWallpaperService
    {
        Task SetWallpaper(WeatherResponse weather);
    }
}
