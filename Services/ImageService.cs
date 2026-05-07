using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkShot.Services
{
    public class ImageService
    {
        public async Task<string> UploadImageAsync(string imagePath)
        {
            await Task.Delay(1000);

            if (string.IsNullOrWhiteSpace(imagePath))
                return null;

            if (!imagePath.EndsWith(".png") &&
                !imagePath.EndsWith(".jpg"))
            {
                throw new Exception("Unsupported image format.");
            }

            return $"asset-{Guid.NewGuid()}";
        }
    }
}
