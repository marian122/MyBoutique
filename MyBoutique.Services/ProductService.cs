using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBoutique.Mappings;
using Microsoft.EntityFrameworkCore;
using MyBoutique.Infrastructures.InputModels;

namespace MyBoutique.Services
{
    public class ProductService : IProductService
    {
        private readonly IDeletableEntityRepository<Product> productRepository;
        private readonly IImageService imageService;

        public ProductService(IDeletableEntityRepository<Product> productRepository, IImageService imageService)
        {
            this.productRepository = productRepository;
            this.imageService = imageService;
        }

        public async Task<bool> CreateProductAsync(CreateProductInputModel input)
        {


            //var result = await this.imageService.CreateImageCollectionAsynq(input.Photos);

            //var ProductImgs = await this.imageService.GetImageCollectionlByIdsAsynq<Image>(result);


            var product = new Product()
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                CategoryName = input.CategoryName,
                CategoryType = input.CategoryType,
                Sizes = input.Sizes,
                Colors = input.Colors,
                CreatedOn = DateTime.Now,
                IsDeleted = false
            };


            //product.Photos = ProductImgs.ToList();

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
                .OrderBy(x => x.CreatedOn)
                .To<TViewModel>()
                .ToListAsync();

        public async Task<TViewModel> GetByIdAsync<TViewModel>(int id)
            => await this.productRepository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}
