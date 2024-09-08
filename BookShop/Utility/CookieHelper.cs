using Microsoft.JSInterop;

namespace BookShop.Utility
{
    public class CookieHelper
    {
        private IJSRuntime _jsRuntime;
        private IJSObjectReference _jSObject = null;

        public CookieHelper(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        private async Task CallJS()
        {
            if (_jSObject is not null)
                return;

            _jSObject = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/js/cookieHelper.js");
        }

        public async Task SetCookie(string name, string value, int days)
        {
            await CallJS();
            await _jSObject.InvokeVoidAsync("setCookie", name, value, days);
        }

        public async Task<string> GetCookie(string name)
        {
            await CallJS();
            return await _jSObject.InvokeAsync<string>("getCookie", name);
        }

        public async Task DeleteCookie(string name)
        {
            await CallJS();
            await _jSObject.InvokeVoidAsync("deleteCookie", name);
        }
    }
}
