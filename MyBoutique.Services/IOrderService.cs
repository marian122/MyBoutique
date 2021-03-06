﻿using MyBoutique.Infrastructures.InputModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface IOrderService
    {
        public Task<bool> CreateOrderAsync(CreateOrderInputModel input);

        public Task<bool> DeleteOrderAsync(int id);

        public Task<bool> DeleteCurrentUserOrderAsync(string userId);

        public Task<bool> DeleteAllOrdersAsync();

        public Task<IEnumerable<TViewModel>> GetAllOrdersAsync<TViewModel>(string sessionId);

        public Task<TViewModel> GetOrderByIdAsync<TViewModel>(int id);
    }
}
