using Microsoft.AspNetCore.Components;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace BlazorMauiWebView
{
    public class MauiDispatcher : Dispatcher
    {
        public static Dispatcher Instance { get; } = new MauiDispatcher();

        private MauiDispatcher()
        {
        }

        public override bool CheckAccess()
        {
            return !Device.IsInvokeRequired;
        }

        public override Task InvokeAsync(Action workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task InvokeAsync(Func<Task> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task<TResult> InvokeAsync<TResult>(Func<TResult> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }

        public override Task<TResult> InvokeAsync<TResult>(Func<Task<TResult>> workItem)
        {
            return Device.InvokeOnMainThreadAsync(workItem);
        }
    }
}
