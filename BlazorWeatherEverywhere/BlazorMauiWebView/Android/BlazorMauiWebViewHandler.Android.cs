#if ANDROID
using Microsoft.Maui.Handlers;
using Android.Webkit;
using static Android.Views.ViewGroup;
using AWebView = Android.Webkit.WebView;
using Microsoft.Maui.Controls;
using Android.Util;
using System;
using Microsoft.Extensions.FileProviders;
using System.Collections.ObjectModel;
using Path = System.IO.Path;

namespace BlazorMauiWebView
{
    public partial class BlazorMauiWebViewHandler : AbstractViewHandler<IBlazorMauiWebView, AWebView>, IWebViewDelegate
    {
        public const string AssetBaseUrl = "file:///android_asset/";

        WebViewClient? _webViewClient;
        WebChromeClient? _webChromeClient;
        private AndroidWebKitWebViewManager _webviewManager;
        internal AndroidWebKitWebViewManager WebviewManager => _webviewManager;

        protected override AWebView CreateNativeView()
        {
            var aWebView = new AWebView(Context!)
            {
#pragma warning disable 618 // This can probably be replaced with LinearLayout(LayoutParams.MatchParent, LayoutParams.MatchParent); just need to test that theory
                LayoutParameters = new Android.Widget.AbsoluteLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent, 0, 0)
#pragma warning restore 618
            };

            if (aWebView.Settings != null)
            {
                aWebView.Settings.JavaScriptEnabled = true;
                aWebView.Settings.DomStorageEnabled = true;
            }

            _webViewClient = GetWebViewClient();
            aWebView.SetWebViewClient(_webViewClient);

            _webChromeClient = GetWebChromeClient();
            aWebView.SetWebChromeClient(_webChromeClient);

            return aWebView;
        }

        protected override void DisconnectHandler(AWebView nativeView)
        {
            nativeView.StopLoading();

            _webViewClient?.Dispose();
            _webChromeClient?.Dispose();
        }

        public static void MapSource(BlazorMauiWebViewHandler handler, IBlazorMauiWebView webView)
        {
            Log.Info("eilon", "MapSource");
            //ViewHandler.CheckParameters(handler, webView);

            IWebViewDelegate webViewDelegate = handler;

            handler.TypedNativeView?.UpdateSource(webView, webViewDelegate);
        }

        private bool RequiredStartupPropertiesSet =>
            //_webview != null &&
            HostPage != null &&
            Services != null;

        public string HostPage { get; private set; }
        public ObservableCollection<RootComponent> RootComponents { get; private set; }
        public IServiceProvider Services { get; private set; }

        private void StartWebViewCoreIfPossible()
        {
            Log.Info("eilon", "StartWebViewCoreIfPossible");

            if (!RequiredStartupPropertiesSet ||
                false)//_webviewManager != null)
            {
                return;
            }


            var resourceAssembly = RootComponents[0].ComponentType.Assembly;

            // We assume the host page is always in the root of the content directory, because it's
            // unclear there's any other use case. We can add more options later if so.
            var contentRootDir = Path.GetDirectoryName(HostPage);
            var hostPageRelativePath = Path.GetRelativePath(contentRootDir, HostPage);
            var fileProvider = new ManifestEmbeddedFileProvider(resourceAssembly, root: contentRootDir);
            Log.Info("eilon", $"ManifestEmbeddedFileProvider from {resourceAssembly.GetName().Name}, root dir = {contentRootDir}, hostpage = {HostPage}, hostRelativeDir = {hostPageRelativePath}");

            _webviewManager = new AndroidWebKitWebViewManager(this, TypedNativeView, Services, MauiDispatcher.Instance, fileProvider, hostPageRelativePath);
            foreach (var rootComponent in RootComponents)
            {
                // Since the page isn't loaded yet, this will always complete synchronously
                _ = rootComponent.AddToWebViewManagerAsync(_webviewManager);
            }
            Log.Info("eilon", "NavigateStart to '/'");
            _webviewManager.Navigate("/");
        }

        public static void MapHostPage(BlazorMauiWebViewHandler handler, IBlazorMauiWebView webView)
        {
            Log.Info("eilon", "MapHostPage = " + webView.HostPage);

            // TODO: Do OnImportantPropertyChanged event here
            handler.HostPage = webView.HostPage;
            handler.StartWebViewCoreIfPossible();
        }

        public static void MapRootComponents(BlazorMauiWebViewHandler handler, IBlazorMauiWebView webView)
        {
            Log.Info("eilon", "MapRootComponents = " + webView.RootComponents.Count);
            for (int i = 0; i < webView.RootComponents.Count; i++)
            {
                var item = webView.RootComponents[i];
                Log.Info("eilon", $"  RootComponents[{i}] = {item.ComponentType.FullName}");
            }

            handler.RootComponents = webView.RootComponents;
            handler.StartWebViewCoreIfPossible();
        }

        public static void MapServices(BlazorMauiWebViewHandler handler, IBlazorMauiWebView webView)
        {
            Log.Info("eilon", "MapServices = " + webView.Services.GetType().FullName);

            handler.Services = webView.Services;
            handler.StartWebViewCoreIfPossible();
        }

        public void LoadHtml(string? html, string? baseUrl)
        {
            Log.Info("eilon", $"LoadHtml = {(html + new string(' ', 50)).Substring(0, 50)}");
            TypedNativeView?.LoadDataWithBaseURL(baseUrl ?? AssetBaseUrl, html ?? string.Empty, "text/html", "UTF-8", null);
        }

        public void LoadUrl(string? url)
        {
            Log.Info("eilon", $"LoadUrl = {(url + new string(' ', 50)).Substring(0, 50)}");
            TypedNativeView?.LoadUrl(url ?? string.Empty);
        }

        protected virtual WebViewClient GetWebViewClient() =>
            new WebKitWebViewClient(this);

        protected virtual WebChromeClient GetWebChromeClient() =>
            new WebChromeClient();
    }
}
#endif
