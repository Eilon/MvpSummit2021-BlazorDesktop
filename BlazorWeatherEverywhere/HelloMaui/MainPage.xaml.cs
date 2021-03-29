using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using WeatherLib;

namespace HelloMaui
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IPage
    {
        private readonly AppState _appState = new();

        public MainPage()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddSingleton<AppState>(_appState);
            serviceCollection.AddSingleton<IWeatherService, AutoWeatherService>();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }

        public IView View
        {
            get => (IView)Content;
            set => Content = (View)value;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            CounterLabel.Text = $"You clicked {_appState.Counter} times. COOOOL!";
        }
    }
}
