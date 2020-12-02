using AutoMapper;
using MyBoutique.Common.Repositories;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class ImageService : IImageService
    {
        readonly IDeletableEntityRepository<Image> repository;
        private readonly MapperConfiguration mapper;

        public ImageService(IDeletableEntityRepository<Image> repository, MapperConfiguration mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> CreateImageAsynq(CreateImageInputModel inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException();
                // TODO: Add errMsg
            }

            var img = new Image()
            {
                Title = inputModel.Title
            };

            this.repository.Add(img);

            var result = await this.repository.SaveChangesAsync();

            return result > 0 ? img.Id : throw new InvalidOperationException();
        }

        public async Task<bool> DeleteImageAsynq(int id)
        {
           var img = await this.repository.GetByIdAsync(id);

            if (img == null)
            {
                throw new ArgumentNullException();
                // TODO: Add errMsg
            }

            img.IsDeleted = true;

            this.repository.Update(img);

            return true;
        }

        public async Task<TViewModel> GetImagelByIdAsynq<TViewModel>(int id)
        {
            var img = await this.repository.GetByIdAsync(id);

            if (img == null)
            {
                throw new ArgumentNullException();
                // TODO: Add errMsg
            }

            var conf = mapper.CreateMapper();

            return conf.Map<TViewModel>(img);
        }
    }
}
