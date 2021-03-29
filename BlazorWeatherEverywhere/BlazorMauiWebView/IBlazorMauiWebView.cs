using Microsoft.Maui;
using System;
using System.Collections.ObjectModel;

namespace BlazorMauiWebView
{
    public interface IBlazorMauiWebView : IView
    {
        // WebView stuff
        string Source { get; set; }


        // Blazor-specific

        string HostPage { get; set; }
        ObservableCollection<RootComponent> RootComponents { get; }
        IServiceProvider Services { get; set; }
    }
}
