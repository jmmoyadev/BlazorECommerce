using Microsoft.JSInterop;

namespace BlazorECommerceWeb_Server.Helpers
{
    public static class JSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("showToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("showToastr", "error", message);
        }
    }
}
