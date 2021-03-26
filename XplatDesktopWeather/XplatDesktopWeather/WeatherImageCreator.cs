using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System.Net.Http;
using System.Threading.Tasks;

namespace XplatDesktopWeather
{
    public class WeatherImageCreator
    {
        public static async Task<Image> CreateWeatherImage(WeatherForecast weatherForecast)
        {
            var i = new Image<Rgba32>(1024, 768);

            i.Mutate(c =>
            {
                c.Fill(Color.Black);
            });

            // Get weather icon
            var http = new HttpClient();
            var imageResponse = await http.GetAsync(weatherForecast.WeatherUri);
            if (imageResponse.IsSuccessStatusCode)
            {
                using var imageStream = await imageResponse.Content.ReadAsStreamAsync();

                // Draw weather icon on image
                var weatherIconImage = await Image.LoadAsync(imageStream);
                weatherIconImage.Mutate(c =>
                {
                    c.Resize(weatherIconImage.Width * 4, weatherIconImage.Height * 4);
                });
                i.Mutate(c =>
                {
                    c.DrawImage(weatherIconImage, new Point(512 - (weatherIconImage.Width / 2), 200), opacity: 1f);
                });
            }

            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.WPF)
            {
                var font = SystemFonts.CreateFont("Arial", 32, FontStyle.Regular);

                var textOptions = new TextGraphicsOptions(
                    new GraphicsOptions() { Antialias = true, },
                    new TextOptions() { HorizontalAlignment = HorizontalAlignment.Center, });


                var glyphs = TextBuilder.GenerateGlyphs(
                    $"Conditions for {weatherForecast.Location}: {weatherForecast.WeatherText}, {weatherForecast.Temperature:0.0}°F",
                    location: new PointF(x: 512, y: 64),
                    new RendererOptions(font)
                    {
                        HorizontalAlignment = textOptions.TextOptions.HorizontalAlignment,
                    });

                i.Mutate(c =>
                {
                    c.Fill(Color.Violet, glyphs);

                //c.DrawText(
                //    textOptions,
                //    $"Conditions for {weatherForecast.Location}: {weatherForecast.WeatherText}, {weatherForecast.Temperature:0.0}°F",
                //    font,
                //    Color.Violet,
                //    new PointF(x: 512, y: 64));
                });
            }

            return i;
        }
    }
}
