using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Infrastructures.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IProductService
    {
        public Task<bool> CreateProductAsync(CreateProductInputModel input);

        public Task<bool> DeleteProductAsync(int id);

        public Task<bool> DeleteProductSizeAsync(int id);

        public Task<bool> DeleteProductColorAsync(int id);

        Task<bool> EditProductAsync(int id, EditProductInputModel input);

        Task<EditProductViewModel> GetProductForEditAsync(int id);

        public Task<TViewModel> GetByIdAsync<TViewModel>(int id);

        public Task<IEnumerable<TViewModel>> GetAllProductsAsync<TViewModel>();
    }
}
