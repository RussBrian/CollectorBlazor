using Microsoft.AspNetCore.Components.Forms;
using System.Text;

namespace Collector.Client.Helpers
{
    public static class ImageConverter
    {
        public static async Task<IList<string>> ConvertImagesListToStringAsync(IList<IBrowserFile> files)
        {
            var images = new List<string>();

            foreach (var file in files)
            {
                var buffer = new byte[file.Size];
                await using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); 
                await stream.ReadAsync(buffer.AsMemory(0, buffer.Length));

                var base64String = Convert.ToBase64String(buffer);
                var mimeType = file.ContentType; 
                images.Add($"data:{mimeType};base64,{base64String}");
            }

            return images;
        }

        public static async Task<string> ConvertImageToStringAsync(IBrowserFile file)
        {
            var buffer = new byte[file.Size];
            await using var stream = file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024); 
            var base64String = Convert.ToBase64String(buffer);
            var mimeType = file.ContentType; 
            return ($"data:{mimeType};base64,{base64String}");
        }

    }
}
