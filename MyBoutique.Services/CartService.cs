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

        public async Task<IEnumerable<TViewModel>> GetAllOrdersAsync<TViewModel>()
            => await this.ordersRepository
            .All()
            .Where(x => x.IsDeleted == false)
            .OrderBy(x => x.Quantity)
            .To<TViewModel>()
            .ToListAsync();

        public async Task<TViewModel> GetOrderByIdAsync<TViewModel>(int id)
            => await this.ordersRepository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();

        // TODO: Implement to display orders only for current session id.
    }
}
