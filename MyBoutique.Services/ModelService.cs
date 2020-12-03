using MyBoutique.Common;
using MyBoutique.Common.Repositories;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Models;
using System;
using MyBoutique.Mappings;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyBoutique.Services
{
    public class ModelService : IModelService
    {
        private readonly IDeletableEntityRepository<Model> repository;
        private readonly MapperConfiguration mapper;

        public ModelService(IDeletableEntityRepository<Model> repository, MapperConfiguration mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateModelAsynq(CreateModelInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException();
                //Add errMgs
            }

            var model = new Model()
            {
                Size = inputModel.Size,
                Color = inputModel.Size,
                CreatedOn = DateTime.Now
            };

            this.repository.Add(model);

            var result = await this.repository.SaveChangesAsync();

            return result > 0 ? model.Id : throw new InvalidOperationException();
            //Add errMgs
        }

        public async Task<bool> DeleteModelAsynq(int id)
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

        public async Task<IEnumerable<TViewModel>> GetAllModelsAsync<TViewModel>()
                  => await  this.repository.All()
                    .OrderBy(x => x.CreatedOn)
                    .To<TViewModel>().ToListAsync();
        public async Task<TViewModel> GetModelByIdAsynq<TViewModel>(int id)
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
