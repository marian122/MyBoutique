using MyBoutique.Services.InputModels;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IOrderService
    {
        public Task<bool> CreateOrderAsync(CreateOrderInputModel input);

        public Task<bool> DeleteOrderAsync(int id);
    }
}
