using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SixLabors.ImageSharp;

namespace XplatDesktopWeather
{
    public class MacDesktopWallpaperService : IDesktopWallpaperService
    {
        public async Task SetWallpaper(Image weatherImage)
        {
            var picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            var newDesktopImagePath = Path.Combine(picturesFolder, DateTimeOffset.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "-weatherpaper.png");
            using var imageStream = new FileStream(newDesktopImagePath, FileMode.Create);
            await weatherImage.SaveAsPngAsync(imageStream);

            var appleScriptLocation = CreateAppleScript(newDesktopImagePath);
            Process.Start("osascript", appleScriptLocation);
        }

        private string CreateAppleScript(string newDesktopImagePath)
        {
            var scriptFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var scriptFile = Path.Combine(scriptFolder, "set_weather_photo.applescript");
            File.WriteAllText(scriptFile, @$"
tell application ""Finder""
    set desktop picture to POSIX file ""{newDesktopImagePath}""
end tell");
            return scriptFile;
        }
    }
}
