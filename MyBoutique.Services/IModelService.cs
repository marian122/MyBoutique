using MyBoutique.Infrastructures.InputModels;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IModelService
    {
        public Task<int> CreateModelAsynq<TViewModel>(CreateModelInputModel inputModel);
    }
}
