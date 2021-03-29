using System;
using Microsoft.Maui.Hosting;

namespace BlazorMauiWebView
{
    public static class BlazorWebViewRegistrationExtensions
    {
        public static TAppHostBuilder RegisterBlazorMauiWebView<TAppHostBuilder>(this TAppHostBuilder appHostBuilder) where TAppHostBuilder : IAppHostBuilder
        {
            if (appHostBuilder is null)
            {
                throw new ArgumentNullException(nameof(appHostBuilder));
            }

            appHostBuilder.RegisterHandler<IBlazorMauiWebView, BlazorMauiWebViewHandler>();

            return appHostBuilder;
        }
    }
}
