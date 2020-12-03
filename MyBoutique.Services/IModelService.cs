using MyBoutique.Infrastructures.InputModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IModelService
    {
        public Task<int> CreateModelAsynq(CreateModelInputModel inputModel);

        public Task<bool> DeleteModelAsynq(int id);

        public Task<TViewModel> GetModelByIdAsynq<TViewModel>(int id);

        public Task<IEnumerable<TViewModel>> GetAllModelsAsync<TViewModel>();

    }
}
