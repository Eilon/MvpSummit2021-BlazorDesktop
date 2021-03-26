using Microsoft.Extensions.DependencyInjection;
using Microsoft.MobileBlazorBindings.WebView.Windows;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace XplatDesktopWeather.Windows
{
    public class MainWindow : FormsApplicationPage
    {
        [STAThread]
        public static void Main()
        {
            var app = new System.Windows.Application();
            app.Run(new MainWindow());
        }

        public MainWindow()
        {
            Title = "Blazor Windows Weather";

            var additionalServices = new ServiceCollection();
            additionalServices.AddSingleton<IDesktopWallpaperService, WindowsDesktopWallpaperService>();

            Forms.Init();
            BlazorHybridWindows.Init();
            LoadApplication(new App(additionalServices: additionalServices));
        }
    }
}
