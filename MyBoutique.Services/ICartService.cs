using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface ICartService
    {
        public Task<IEnumerable<TViewModel>> GetAllOrdersAsync<TViewModel>();

        public Task<TViewModel> GetOrderByIdAsync<TViewModel>(int id);
    }
}
