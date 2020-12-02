using AutoMapper;
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
        private readonly MapperConfiguration mapper;

        public OrderDataService(IDeletableEntityRepository<OrderData> repository, MapperConfiguration mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateOrderDataAsynq(OrderDataInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            var data = new OrderData()
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Adress = inputModel.Adress,
                Phone = inputModel.Phone,
                PromoCode = inputModel.PromoCode,
                CreatedOn = DateTime.Now,
            };

            this.repository.Add(data);

            var result = await this.repository.SaveChangesAsync();

            return result > 0 ? data.Id : throw new InvalidOperationException();
            //Add errMgs
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
        {
            var model = await this.repository.GetByIdAsync(id);

            if (model == null)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            var conf = mapper.CreateMapper();

            return conf.Map<TViewModel>(model);
        }
    }
}
