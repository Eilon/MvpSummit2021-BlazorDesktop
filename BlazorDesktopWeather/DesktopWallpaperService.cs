using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDesktopWeather
{
    public class DesktopWallpaperService : IDesktopWallpaperService
    {
        public async Task SetWallpaper(WeatherResponse weather)
        {
            var http = new HttpClient();
            var imageResponse = await http.GetAsync("https://apidev.accuweather.com/developers/Media/Default/WeatherIcons/33-s.png");
            if (imageResponse.IsSuccessStatusCode)
            {
                var imageStream = await imageResponse.Content.ReadAsStreamAsync();
                var weatherIconImage = Image.FromStream(imageStream);

                using var image = new Bitmap(1024, 768, PixelFormat.Format24bppRgb);
                using var g = Graphics.FromImage(image);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                g.DrawString(weather.WeatherText, new Font(FontFamily.GenericSansSerif, 40f), Brushes.PowderBlue, 50, 50);

                g.DrawImage(weatherIconImage, new Rectangle(100, 400, weatherIconImage.Width * 5, weatherIconImage.Height * 5));

                var picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                var newDesktopImagePath = Path.Combine(picturesFolder, DateTimeOffset.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-weatherpaper.png");
                image.Save(newDesktopImagePath, ImageFormat.Png);

                //var hr = SetBackgroud(newDesktopImagePath);
            }
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
