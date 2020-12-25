using Microsoft.AspNetCore.Http;
using MyBoutique.Common.Repositories;
using MyBoutique.Mappings;
using MyBoutique.Models;
using MyBoutique.Services.Cloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> repository;
        private readonly ICloudinaryService cloudinaryService;

        public ImageService(IDeletableEntityRepository<Image> repository, ICloudinaryService cloudinaryService)
        {
            this.repository = repository;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<bool> CreateImageCollectionAsynq(IFormFileCollection inputModel)
        {
            if (inputModel == null)
            {
                throw new ArgumentNullException();
                // TODO: Add errMsg
            }


            foreach (var file in inputModel)
            {
                await this.cloudinaryService.UploadPictureAsync(file);
               
                //var img = new Image()
                //{
                //    Title = file.Name,
                //    Path = fileUrl

                //};

                //this.repository.Add(img);
            }


            //var result = await this.repository.SaveChangesAsync();

            return true;
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
