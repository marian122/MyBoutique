using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IImageService
    {
        public Task<IList<int>> CreateImageCollectionAsynq (IFormFileCollection inputModel);

        public Task<bool> DeleteImageAsynq(int id);

        public Task<IEnumerable<TViewModel>> GetImageCollectionlByIdsAsynq<TViewModel>(IList<int> id);

    }
}
