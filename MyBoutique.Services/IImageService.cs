using MyBoutique.Infrastructure.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IImageService
    {
        public Task<IList<int>> CreateImageCollectionAsynq (CreateImageInputModel inputModel);

        public Task<bool> DeleteImageAsynq(int id);

        public Task<IEnumerable<TViewModel>> GetImageCollectionlByIdsAsynq<TViewModel>(IList<int> id);

    }
}
