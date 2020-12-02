using MyBoutique.Infrastructure.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IImageService
    {
        public Task<int> CreateImageAsynq(CreateImageInputModel inputModel);

        public Task<bool> DeleteImageAsynq(int id);

        public Task<TViewModel> GetImagelByIdAsynq<TViewModel>(int id);
    }
}
