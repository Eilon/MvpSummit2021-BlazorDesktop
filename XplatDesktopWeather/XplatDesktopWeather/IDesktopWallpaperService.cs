using SixLabors.ImageSharp;
using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public interface IDesktopWallpaperService
    {
        Task SetWallpaper(Image weatherImage);
    }
}
