using System;
using System.Collections.ObjectModel;
using Microsoft.Maui;

namespace BlazorMauiWebView
{

    public class BlazorMauiWebView : Microsoft.Maui.Controls.View, IBlazorMauiWebView
    {
        private string _source;

        public string Source
        {
            get
            {
#if ANDROID
                Android.Util.Log.Info("eilon", "get_Source = " + _source);
#endif
                return _source;
            }
            set
            {
#if ANDROID
                Android.Util.Log.Info("eilon", "set_Source: " + value);
#endif
                _source = value;
            }
        }

        public string HostPage
        {
            get;
            set;
        }

        public ObservableCollection<RootComponent> RootComponents { get; } = new();

        public IServiceProvider Services { get; set; }
    }
}
