using Microsoft.Maui;
using Microsoft.Maui.Handlers;

namespace BlazorMauiWebView
{
    public partial class BlazorMauiWebViewHandler
	{
		public static PropertyMapper<IBlazorMauiWebView, BlazorMauiWebViewHandler> WebViewMapper = new PropertyMapper<IBlazorMauiWebView, BlazorMauiWebViewHandler>(ViewHandler.ViewMapper)
		{
			[nameof(IBlazorMauiWebView.Source)] = MapSource,
			[nameof(IBlazorMauiWebView.HostPage)] = MapHostPage,
			[nameof(IBlazorMauiWebView.RootComponents)] = MapRootComponents,
			[nameof(IBlazorMauiWebView.Services)] = MapServices,
		};

		public BlazorMauiWebViewHandler() : base(WebViewMapper)
		{
		}

		public BlazorMauiWebViewHandler(PropertyMapper mapper) : base(mapper ?? WebViewMapper)
		{
		}
	}
}
