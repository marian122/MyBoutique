using MyBoutique.Infrastructures.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IOrderService
    {
        public Task<bool> CreateOrderAsync(CreateOrderInputModel input);

        public Task<bool> DeleteOrderAsync(int id);

        public Task<bool> DeleteAllOrdersAsync();

        public Task<IEnumerable<TViewModel>> GetAllOrdersAsync<TViewModel>();

        public Task<TViewModel> GetOrderByIdAsync<TViewModel>(int id);
    }
}
