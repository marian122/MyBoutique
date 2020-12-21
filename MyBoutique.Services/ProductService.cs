﻿using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBoutique.Mappings;
using Microsoft.EntityFrameworkCore;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Infrastructure.InputModels;

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

        public async Task<bool> EditProductAsync(int id, EditProductInputModel input)
        {
            var currentProduct = this.GetProductById(id);

            if (currentProduct != null)
            {
                currentProduct.Name = input.Name;
                currentProduct.CategoryName = input.CategoryName;
                currentProduct.CategoryType = input.CategoryType;
                currentProduct.Sizes = input.Sizes;
                currentProduct.Colors = input.Colors;
                currentProduct.Price = input.Price;
                currentProduct.Description = input.Description;
                //currentProduct.Photos = input.Photos;

                this.productRepository.Update(currentProduct);
                await this.productRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.ProductEditError);

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

        public async Task<EditProductViewModel> GetProductForEditAsync(int id)
        {
            var product = this.GetProductById(id);

            if (product != null)
            {
                var result = new EditProductViewModel()
                {
                    Name = product.Name,
                    CategoryName = product.CategoryName,
                    CategoryType = product.CategoryType,
                    Sizes = product.Sizes,
                    Colors = product.Colors,
                    Price = product.Price,
                    Description = product.Description,
                    //Photos = product.Photos,
                };

                return result;
            }
            throw new InvalidOperationException(GlobalConstants.ProductSearchForEditError);
        }

        public Product GetProductById(int id)
            => this.productRepository.All()?.FirstOrDefault(x => x.Id == id);
    }
}
