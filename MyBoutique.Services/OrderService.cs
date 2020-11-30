using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Models;
using MyBoutique.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    UserId = "placeHereSessionId",
                    ProductId = product.Id,
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
    }
}
