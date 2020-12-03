using Microsoft.EntityFrameworkCore;
using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public CartService(IDeletableEntityRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IEnumerable<TViewModel> AllOrders<TViewModel>()
         =>  this.cartRepository.All()
            .To<TViewModel>()
            .ToList();

        public async Task<bool> DeleteOrderCartAsync<TViewModel>(int id)
        {
            var order = this.cartRepository.All().FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                this.cartRepository.Delete(order);
                await this.cartRepository.SaveChangesAsync();
                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteOrderError);
        }


        public async Task<int> MakeOrderCartAsync<TViewModel>(CreateCartInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            var cart = new Cart()
            {
                OrderDataId = inputModel.OrderDataId,
                TotalPrice = inputModel.TotalPrice,
                CreatedOn = DateTime.UtcNow,
                Orders = inputModel.Orders.AsQueryable().To<Order>().ToList(),
                SessionId = inputModel.SessionId
            };

            this.cartRepository.Add(cart);

            var result = await this.cartRepository.SaveChangesAsync();

            return result > 0 ? cart.Id : throw new InvalidOperationException();


        }

        public async Task<TViewModel> GetOrderByIdAsynq<TViewModel>(int id)
           => await this.cartRepository.All()
           .Where(x => x.Id == id && x.IsDeleted == false)
           .To<TViewModel>()
           .FirstOrDefaultAsync();


        // TODO: Implement to display orders only for current session id.
    }
}
