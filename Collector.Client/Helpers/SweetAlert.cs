using Microsoft.JSInterop;

namespace Collector.Client.Helpers
{
    public class SweetAlert
    {
        private readonly IJSRuntime _jsRuntime;

        public SweetAlert(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowAlert(string title, string message, string icon = "success")
        {
            await _jsRuntime.InvokeVoidAsync("Swal.fire", new
            {
                title,
                text = message,
                icon
            });
        }
    }
}
