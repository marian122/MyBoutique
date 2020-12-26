using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IImageService
    {
        public Task<bool> CreateImageCollectionAsynq (IFormFileCollection inputModel);

        public Task<bool> DeleteImageAsynq(int id);


        public Task<IEnumerable<TViewModel>> GetImageCollectionlByProductIdsAsynq<TViewModel>(int id);

    }
}
