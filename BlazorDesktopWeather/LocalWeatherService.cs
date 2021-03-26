using System;
using System.Threading.Tasks;

namespace BlazorDesktopWeather
{
    public class LocalWeatherService : IWeatherService
    {
        public async Task<WeatherResponse> GetWeatherAsync(string location)
        {
            await Task.Delay(5000);

            return new WeatherResponse()
            {
                Location = "Alderaan",
                WeatherText = "Too cold",
                WeatherIcon = 33,
                IsDayTime = true,
                Temperature = -432,
                RelativeHumidity = 0,
                WindSpeed = 0,
                Pressure = 0,
                UVIndex = 0,
                RetrievedDateTimeOffset = DateTimeOffset.Now,
                WeartherUri = "https://apidev.accuweather.com/developers/Media/Default/WeatherIcons/33-s.png"
            };
        }
    }
}
