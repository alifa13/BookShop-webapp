using Microsoft.JSInterop;

namespace BookShop.Utility
{
    public class ToastHelper
    {
        private IJSRuntime _jsRuntime;

        public ToastHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Notify(string message, ToastType type)
        {
            switch (type)
            {
                case ToastType.Success:
                    await _jsRuntime.InvokeVoidAsync("notifySuccess", message);
                    break;
                case ToastType.Warning:
                    await _jsRuntime.InvokeVoidAsync("notifyWarning", message);
                    break;
                case ToastType.Error:
                    await _jsRuntime.InvokeVoidAsync("notifyError", message);
                    break;
                default:
                    break;
            }
        }
    }

    public enum ToastType
    {
        Success,
        Warning,
        Error
    }
}
