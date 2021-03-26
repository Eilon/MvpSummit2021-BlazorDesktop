using ImageMagick;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public class WindowsDesktopWallpaperService : IDesktopWallpaperService
    {
        public async Task SetWallpaper(MagickImage weatherImage)
        {
            var picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var newDesktopImagePath = Path.Combine(picturesFolder, DateTimeOffset.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-weatherpaper.png");
            using var imageStream = new FileStream(newDesktopImagePath, FileMode.Create);
            await weatherImage.WriteAsync(imageStream, MagickFormat.Png);

            //var hr = SetBackgroud(newDesktopImagePath);
        }

        private static int SetBackgroud(string fileName)
        {
            const int UAction_SPI_SETDESKWALLPAPER = 0x0014;
            return SystemParametersInfo(UAction_SPI_SETDESKWALLPAPER, 0, new StringBuilder(fileName), 0x2);
        }

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo", CharSet = CharSet.Unicode)]
        private static extern int SystemParametersInfo(int uAction, int uParam, StringBuilder lpvParam, int fuWinIni);
    }
}
