using Microsoft.AspNetCore.Components.WebView;
using System;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.FileProviders;

namespace BlazorMauiWebView
{
    public abstract class MauiWebViewManager : WebViewManager
    {
        public MauiWebViewManager(IServiceProvider services, Dispatcher dispatcher, Uri appOrigin, IFileProvider fileProvider, string hostPageRelativePath)
            : base(services, dispatcher, appOrigin, fileProvider, hostPageRelativePath)
        {
        }
    }

}
