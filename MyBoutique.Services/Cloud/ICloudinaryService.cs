using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBoutique.Services.Cloud
{
    public interface ICloudinaryService
    {
        Task<string> UploadPhotoAsync(IFormFile picture, string name, string folderName);
        Task<string> UploadPictureAsync(IFormFile pictureFile);
    }
}
