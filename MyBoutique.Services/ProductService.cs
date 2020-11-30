using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Models;
using MyBoutique.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBoutique.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MyBoutique.Services
{
    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;

        public ProductService(IDeletableEntityRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> CreateProductAsync(CreateProductInputModel input)
        {
            var product = new Product()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CategoryType = input.CategoryType,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };

            if (product != null && product.Price > 0)
            {
                this.productRepository.Add(product);
                await this.productRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.CreateProductError);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = this.productRepository
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                this.productRepository.Delete(product);
                await this.productRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteProductError);
        }

        public async Task<IEnumerable<TViewModel>> GetAllProductsAsync<TViewModel>()
            => await this.productRepository.All()
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.Price)
                .To<TViewModel>()
                .ToListAsync();

        public async Task<TViewModel> GetByIdAsync<TViewModel>(int id)
            => await this.productRepository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}
