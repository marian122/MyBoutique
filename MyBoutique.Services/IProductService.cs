using MyBoutique.Infrastructures.InputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IProductService
    {
        public Task<bool> CreateProductAsync(CreateProductInputModel input);

        public Task<bool> DeleteProductAsync(int id);

        public Task<TViewModel> GetByIdAsync<TViewModel>(int id);

        public Task<IEnumerable<TViewModel>> GetAllProductsAsync<TViewModel>();
    }
}
