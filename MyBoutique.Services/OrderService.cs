using Microsoft.EntityFrameworkCore;
using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Mappings;
using MyBoutique.Models;
using MyBoutique.Infrastructures.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public OrderService(IDeletableEntityRepository<Order> ordersRepository,
                            IDeletableEntityRepository<Product> productsRepository)
        {
            this.ordersRepository = ordersRepository;
            this.productsRepository = productsRepository;
        }
        public async Task<bool> CreateOrderAsync(CreateOrderInputModel input)
        {
            var product = this.productsRepository.All().FirstOrDefault(x => x.Id == input.ProductId);

            if (product != null && input.Quantity > 0)
            {
                var order = new Order()
                {
                    UserId = input.UserId,
                    Product = product,
                    ProductId = product.Id,
                    Color = input.Color,
                    Size = input.Size,
                    Quantity = input.Quantity,
                    TotalPrice = product.Price * input.Quantity,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false
                    
                };

                this.ordersRepository.Add(order);

                await this.ordersRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.CreateOrderError);
        }

        public async Task<bool> DeleteAllOrdersAsync()
        {
            var ordersInCart = this.ordersRepository.All().Where(x => x.IsDeleted == false);
            if (ordersInCart.Any())
            {
                foreach (var order in ordersInCart)
                {
                    order.IsDeleted = true;
                }

                var result = await this.ordersRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteAllOrdersError);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = this.ordersRepository.All().FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                this.ordersRepository.Delete(order);
                await this.ordersRepository.SaveChangesAsync();
                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteOrderError);
        }

        public async Task<IEnumerable<TViewModel>> GetAllOrdersAsync<TViewModel>(string sessionId)
            => await this.ordersRepository
            .All()
            .Where(x => x.IsDeleted == false && x.UserId == sessionId)
            .OrderBy(x => x.Quantity)
            .To<TViewModel>()
            .ToListAsync();

        public async Task<TViewModel> GetOrderByIdAsync<TViewModel>(int id)
            => await this.ordersRepository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}
