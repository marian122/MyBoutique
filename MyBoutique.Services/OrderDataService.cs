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
                    DeliveryType = inputModel.DeliveryType,
                    PromoCode = inputModel.PromoCode,
                    AdditionalInformation = inputModel.AdditionalInformation,
                    CreatedOn = DateTime.Now,
                    Orders = orders,
                    SubTotal = orders.Sum(x => x.TotalPrice),
                    IsFinished = true,
                };

                this.repository.Add(data);
                await this.repository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.FinishOrderError);
        }

        public async Task<bool> DeleteAllOrdersDataAsync()
        {
            var ordersInCart = this.repository.All().Where(x => x.IsDeleted == false);
            if (ordersInCart.Any())
            {
                foreach (var order in ordersInCart)
                {
                    order.IsDeleted = true;
                }

                var result = await this.repository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteAllOrdersDataError);
        }

        public async Task<bool> DeleteOrderDataAsynq(int id)
        {
            var orderData = this.repository.All().FirstOrDefault(x => x.Id == id);

            if (orderData != null)
            {
                this.repository.Delete(orderData);
                await this.repository.SaveChangesAsync();
                return true;
            }

            throw new InvalidOperationException(GlobalConstants.DeleteOrderError);
        }

        public async Task<IEnumerable<TViewModel>> GetAllOrderDataAsynq<TViewModel>()
         => await this.repository.All()
            .Where(x => x.IsDeleted == false && x.IsFinished == true)
            .OrderBy(x => x.CreatedOn)
            .Include(x => x.Orders)
            .ThenInclude(x => x.Product)
            .To<TViewModel>()
            .ToListAsync();

        public async Task<TViewModel> GetOrderDataByIdAsynq<TViewModel>(int id)
         => await this.repository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}
