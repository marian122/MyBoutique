using MyBoutique.Infrastructure.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface ICartService
    {
        public Task<int> MakeOrderCartAsync<TViewModel>(CreateCartInputModel inputModel);
        public IEnumerable<TViewModel> AllOrders<TViewModel>();

        public Task<TViewModel> GetOrderByIdAsynq<TViewModel>(int id);

        public Task<IEnumerable<TViewModel>> GetAllCartOrderBySessionId<TViewModel>(string id);

        public Task<bool> DeleteOrderCartAsync<TViewModel>(int id);

    }
}
