using ImageMagick;
using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public interface IDesktopWallpaperService
    {
        Task SetWallpaper(MagickImage weatherImage);
    }
}
