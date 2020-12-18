using AutoMapper;
using Microsoft.AspNetCore.Http;
using MyBoutique.Common.Repositories;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Mappings;
using MyBoutique.Models;
using MyBoutique.Services.Cloud;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class ImageService : IImageService
    {
        readonly IDeletableEntityRepository<Image> repository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(IDeletableEntityRepository<Image> repository, ICloudinaryService cloudinaryService)
        {
            this.repository = repository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IList<int>> CreateImageCollectionAsynq(IFormFileCollection inputModel)
        {

            var results = new List<int>();

            if (inputModel == null)
            {
                throw new ArgumentNullException();
                // TODO: Add errMsg
            }


            foreach (var file in inputModel)
            {
                var fileUrl = await this.cloudinaryService.UploadPictureAsync(file);
               
                var img = new Image()
                {
                    Title = file.Name,
                    Path = fileUrl

                };

                results.Add(img.Id);

                this.repository.Add(img);
            }


            await this.repository.SaveChangesAsync();

            return results;
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

       

        public Task<IEnumerable<TViewModel>> GetImageCollectionlByIdsAsynq<TViewModel>(IList<int> ids)
        {
            var colection = new List<TViewModel>();

            foreach (var id in ids)
            {
                var img = this.repository.All().FirstOrDefault(a => a.Id == id);

                if (img != null)
                {
                    colection.Add(img.MapTo<TViewModel>());
                }

            }

            return (Task<IEnumerable<TViewModel>>)colection.AsEnumerable<TViewModel>();
        }
    }
}
