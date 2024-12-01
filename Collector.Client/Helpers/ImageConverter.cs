using Collector.Client.Dtos.Login;
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

        public static async Task<string> ConvertSingleImageToStringAsync(IBrowserFile files)
        {
            var buffer = new byte[files.Size];
            await using var stream = files.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);
            await stream.ReadAsync(buffer.AsMemory(0, buffer.Length));

            var base64String = Convert.ToBase64String(buffer);
            var mimeType = files.ContentType;
            var image = ($"data:{mimeType};base64,{base64String}");
            return image;
        }

        public static async Task<List<IFormFile>> ConvertBrowserFilesToFormFilesAsync(IEnumerable<IBrowserFile> browserFiles)
        {
            int count = 0;
            var formFiles = new List<IFormFile>();

            foreach (var file in browserFiles)
            {
                var memoryStream = new MemoryStream();
                await file.OpenReadStream().CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var formFile = new FormFile(memoryStream, 0, memoryStream.Length, $"images[{count}]", file.Name)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = file.ContentType
                };
                count++;
                formFiles.Add(formFile);
            }
            return formFiles;
        }

        public static async Task<IFormFile> ConvertToIFormFile(IBrowserFile file)
        {
            var formFiles = new List<IFormFile>();

            var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return  new FormFile(memoryStream, 0, memoryStream.Length, $"images[{0}]", file.Name)
            {
                Headers = new HeaderDictionary(),
                ContentType = file.ContentType
            };
            
        }
    }
}
