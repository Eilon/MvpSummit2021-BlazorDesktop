using ImageMagick;
using System.Net.Http;
using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public class WeatherImageCreator
    {
        public static async Task<MagickImage> CreateWeatherImage(WeatherForecast weatherForecast)
        {
            var i = new MagickImage(MagickColors.Black, 1024, 768);

            // Get weather icon
            var http = new HttpClient();
            var imageResponse = await http.GetAsync(weatherForecast.WeatherUri);
            if (imageResponse.IsSuccessStatusCode)
            {
                using var imageStream = await imageResponse.Content.ReadAsStreamAsync();

                // Draw weather icon on image
                var weatherIconImage = new MagickImage(imageStream);
                weatherIconImage.Scale(new Percentage(400));
                i.Composite(weatherIconImage, 512 - (weatherIconImage.Width / 2), 200);
            }

            new Drawables()
              // Weather text caption
              .FontPointSize(32)
              .Font("Arial")
              .StrokeColor(MagickColors.Violet)
              .FillColor(MagickColors.White)
              .TextAlignment(TextAlignment.Center)
              .Text(x: 512, y: 64, $"Conditions for {weatherForecast.Location}: {weatherForecast.WeatherText}, {weatherForecast.Temperature:0.0}°F")
              // Draw on image
              .Draw(i);

            return i;
        }
    }
}
