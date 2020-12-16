using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBoutique.Services.Cloudinary
{
    public interface ICloudinaryService
    {
        public interface ICloudinaryService
        {
            Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
        }
    }
}
