using Microsoft.EntityFrameworkCore;
using MyBoutique.Common.Repositories;
using MyBoutique.Mappings;
using MyBoutique.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class CartService : ICartService
    {
        private readonly IDeletableEntityRepository<Order> ordersRepository;
        private readonly IDeletableEntityRepository<Cart> cartRepository;

        public CartService(IDeletableEntityRepository<Order> ordersRepository,
                           IDeletableEntityRepository<Cart> cartRepository)
        {
            this.ordersRepository = ordersRepository;
            this.cartRepository = cartRepository;
        }

        public Task<int> MakeOrderCartAsync<TViewModel>()
        {
            throw new System.NotImplementedException();
        }

        // TODO: Implement to display orders only for current session id.
    }
}
