using MyBoutique.Infrastructures.InputModels;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IModelService
    {
        public Task<int> CreateModelAsynq(CreateModelInputModel inputModel);

        public Task<bool> DeleteModelAsynq(int id);

        public Task<TViewModel> GetModelByIdAsynq<TViewModel>(int id);

    }
}
