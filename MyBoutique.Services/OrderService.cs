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
        private readonly IDeletableEntityRepository<Picture> pictureRepository;

        public OrderService(IDeletableEntityRepository<Order> ordersRepository,
                            IDeletableEntityRepository<Product> productsRepository,
                             IDeletableEntityRepository<Picture> pictureRepository)
        {
            this.ordersRepository = ordersRepository;
            this.productsRepository = productsRepository;
            this.pictureRepository = pictureRepository;
        }
        public async Task<bool> CreateOrderAsync(CreateOrderInputModel input)
        {
            var product = this.productsRepository.All().FirstOrDefault(x => x.Id == input.ProductId);
            var picture = this.pictureRepository.All().FirstOrDefault(x => x.ProductId == product.Id).Url;

            if (product != null && input.Quantity > 0)
            {
                var order = new Order()
                {
                    UserId = input.UserId,
                    Product = product,
                    ProductId = product.Id,
                    PicUrl = picture,
                    Color = input.Color,
                    Size = input.Size,
                    Quantity = input.Quantity,
                    TotalPrice = product.Price * input.Quantity,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,

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

        public async Task<bool> DeleteCurrentUserOrderAsync(string userId)
        {
            var orders = await this.ordersRepository.All().Where(x => x.UserId == userId).ToListAsync();
            if (orders.Count != 0)
            {
                foreach (var order in orders)
                {
                    this.ordersRepository.Delete(order);
                }
                await this.ordersRepository.SaveChangesAsync();
                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteOrderError);
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
            .Include(x => x.Product)
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
