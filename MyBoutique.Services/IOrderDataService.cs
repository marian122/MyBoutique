using MyBoutique.Infrastructure.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IOrderDataService
    {
        public Task<bool> CreateOrderDataAsynq(OrderDataInputModel inputModel);

        public Task<bool> DeleteOrderDataAsynq(int id);

        public Task<bool> DeleteAllOrdersDataAsync();

        public Task<TViewModel> GetOrderDataByIdAsynq<TViewModel>(int id);

        public Task<IEnumerable<TViewModel>> GetAllOrderDataAsynq<TViewModel>();
    }
}
