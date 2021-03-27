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
                    c.Resize(weatherIconImage.Width * 2, weatherIconImage.Height * 2);
                });
                i.Mutate(c =>
                {
                    var xGap = weatherIconImage.Width + 10;
                    var yGap = weatherIconImage.Height / 2;
                    for (int i = -3; i <= 3; i++)
                    {
                        var leftOffset = 512 + i * xGap - (weatherIconImage.Width / 2);
                        var topOffset = 400 + i * yGap;
                        c.DrawImage(weatherIconImage, new Point(leftOffset, topOffset), opacity: 1f - ((3 - i) * 0.15f));
                    }
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
                    c.Fill(new LinearGradientBrush(
                        p1: new PointF(0, 0),
                        p2: new PointF(100, 100),
                        repetitionMode: GradientRepetitionMode.Reflect,
                        colorStops: new[]
                        {
                        new ColorStop(0f, Color.Violet),
                        new ColorStop(0.5f, Color.Blue),
                        new ColorStop(1f, Color.Orange),
                        }), glyphs);
                });
            }

            return i;
        }
    }
}
