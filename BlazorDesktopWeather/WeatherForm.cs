using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace BlazorDesktopWeather
{
    public partial class WeatherForm : Form
    {
        private IWeatherService _weatherService;

        public WeatherForm()
        {
            _weatherService = new LocalWeatherService();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddSingleton<IDesktopWallpaperService, DesktopWallpaperService>();
            serviceCollection.AddSingleton<IWeatherService>(_weatherService);

            InitializeComponent();

            WeatherDetailsBlazorWebView.HostPage = @"wwwroot\index.html";
            WeatherDetailsBlazorWebView.Services = serviceCollection.BuildServiceProvider();
            WeatherDetailsBlazorWebView.RootComponents.Add<Main>("#app");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PollWeather();
        }

        private async void PollWeather()
        {
            var weather = await _weatherService.GetWeatherAsync(location: "wherever");
            UpdateForm(weather);

            //var client = new WeatherClient(GrpcChannel.ForAddress(serviceUrl));
            //var weatherService = new GrpcWeatherForecastService(client);

            //await foreach (var message in weatherService.GetStreamingWeather(cts.Token))
            //{
            //    UpdateForm(message);
            //};
        }

        private void UpdateForm(WeatherResponse weatherResponse)
        {
            Invoke((Action)(() =>
            {
                City.Text = weatherResponse.Location;
                WeatherIcon.Load(weatherResponse.WeartherUri);
                Temperature.Text = (weatherResponse.Temperature == -432) ? "9K" : weatherResponse.Temperature.ToString();
                WeatherText.Text = weatherResponse.WeatherText;
                //Pressure.Text = $"{weatherResponse.Pressure.ToString()} in";
                //Wind.Text = $"{weatherResponse.WindSpeed.ToString()} mph";
                //Humidity.Text = $"{weatherResponse.RelativeHumidity.ToString()} %";
                //UVIndex.Text = weatherResponse.UVIndex.ToString();
                var localTime = weatherResponse.RetrievedDateTimeOffset.ToLocalTime();
                Updated.Text = $"Updated at {localTime.ToString("h:mm:ss tt")}";
            }));
        }
    }
}
