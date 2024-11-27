using Microsoft.AspNetCore.Components.Forms;

namespace Collector.Client.Helpers
{
    public static class ImageConverter
    {
        public static IList<string> ConvertImagesToString(IList<IBrowserFile> files)
        {
            IList<string> images = [];

            foreach (var file in files)
            {
                var buffer = new byte[file.Size];
                file.OpenReadStream().ReadAsync(buffer);
                images.Add($"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}");
            }
            return images;
        }
    }
}
