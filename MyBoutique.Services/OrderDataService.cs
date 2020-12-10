using AutoMapper;
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
    public class OrderDataService : IOrderDataService
    {
        private readonly IDeletableEntityRepository<OrderData> repository;
        private readonly IDeletableEntityRepository<Order> orderRepository;

        public OrderDataService(IDeletableEntityRepository<OrderData> repository,
                                IDeletableEntityRepository<Order> orderRepository)
        {
            this.repository = repository;
            this.orderRepository = orderRepository;
        }

        public async Task<bool> CreateOrderDataAsynq(OrderDataInputModel inputModel)
        {
            //get all orders
            var orders = await this.orderRepository
            .All()
            .Where(x => x.IsDeleted == false)
            .OrderBy(x => x.Quantity)
            .ToListAsync();

            if (inputModel != null && orders.Count >= 1)
            {
                var data = new OrderData()
                {
                    FirstName = inputModel.FirstName,
                    LastName = inputModel.LastName,
                    Address = inputModel.Address,
                    City = inputModel.City,
                    Email = inputModel.Email,
                    Phone = inputModel.Phone,
                    PromoCode = inputModel.PromoCode,
                    CreatedOn = DateTime.Now,
                    Orders = orders,
                };

                this.repository.Add(data);
                await this.repository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.FinishOrderError);
        }

        public async Task<bool> DeleteOrderDataAsynq(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            var model = await this.repository.GetByIdAsync(id);

            if (model == null)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            model.IsDeleted = true;

            this.repository.Update(model);

            return true;
        }

        public IEnumerable<TViewModel> GetAllOrderDataAsynq<TViewModel>()
                  => this.repository.All()
                    .OrderBy(x => x.CreatedOn)
                    .To<TViewModel>();

        public async Task<TViewModel> GetOrderDataByIdAsynq<TViewModel>(int id)
         => await this.repository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}
