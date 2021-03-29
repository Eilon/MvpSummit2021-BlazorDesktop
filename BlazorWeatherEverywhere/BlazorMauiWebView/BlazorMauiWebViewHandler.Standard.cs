#if !ANDROID && !IOS
using Microsoft.Maui;
using Microsoft.Maui.Handlers;
using System;

namespace BlazorMauiWebView
{
    public partial class BlazorMauiWebViewHandler : AbstractViewHandler<IBlazorMauiWebView, object>
    {
        protected override object CreateNativeView() => throw new NotImplementedException();

        public static void MapSource(IViewHandler handler, IBlazorMauiWebView webView) { }
    }
}
#endif
