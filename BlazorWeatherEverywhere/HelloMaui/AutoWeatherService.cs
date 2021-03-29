using Xamarin.Essentials;
using System;
using System.Threading.Tasks;
using WeatherLib;

namespace HelloMaui
{
    public class AutoWeatherService : IWeatherService
    {
        private Random _random = new Random();
        public async Task<WeatherForecast> GetWeatherAsync(string location)
        {
            // Artificial delay to make it "look" async
            await Task.Delay(1000);

            location ??= "seattle";

            try
            {
                var geoLoc = await Geolocation.GetLocationAsync();
                if (geoLoc != null)
                {
                    location = $"{geoLoc.Latitude:0}N, {geoLoc.Longitude:0}W";
                }
            }
            catch (Exception)
            {
                // Unable to get location
            }
            return new WeatherForecast()
            {
                Location = location,
                WeatherText = "Too cold",
                WeatherIcon = 13,
                IsDayTime = true,
                Temperature = 48 + _random.Next(-10, 10),
                RelativeHumidity = 20,
                WindSpeed = 5,
                Pressure = 1,
                UVIndex = 2,
                RetrievedTime = DateTimeOffset.Now,
                WeatherUri = "https://developer.accuweather.com/sites/default/files/13-s.png"
            };
        }
    }
}
