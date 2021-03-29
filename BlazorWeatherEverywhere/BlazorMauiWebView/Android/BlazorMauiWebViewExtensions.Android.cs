#if ANDROID
using AWebView = Android.Webkit.WebView;
using Microsoft.Maui.Controls;
using Android.Util;

namespace BlazorMauiWebView
{
    public static class BlazorMauiWebViewExtensions
    {
        public static void UpdateSource(this AWebView nativeWebView, IBlazorMauiWebView webView)
        {
            nativeWebView.UpdateSource(webView, null);
        }

        public static void UpdateSource(this AWebView nativeWebView, IBlazorMauiWebView webView, IWebViewDelegate? webViewDelegate)
        {
            Log.Info("eilon", $"UpdateSource from native={nativeWebView.Url} to new={webView.Source}");
            if (webViewDelegate != null)
                nativeWebView.LoadUrl(webView.Source);
        }
    }
}
#endif
