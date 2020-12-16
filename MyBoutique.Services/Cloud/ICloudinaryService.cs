using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyBoutique.Services.Cloud
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile);
    }
}
