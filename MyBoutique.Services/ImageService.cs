using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDeletableEntityRepository<Picture> repository;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IDeletableEntityRepository<Product> productsRepository;

        public ImageService(IDeletableEntityRepository<Picture> repository, 
            ICloudinaryService cloudinaryService,
            IDeletableEntityRepository<Product> productsRepository)
        {
            this.repository = repository;
            this.cloudinaryService = cloudinaryService;
            this.productsRepository = productsRepository;
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
                var fileUrl = await this.cloudinaryService.UploadPictureAsync(file);

                var product = this.productsRepository.All().OrderByDescending(x => x.CreatedOn).FirstOrDefault();
                var img = new Picture()
                {
                    CreatedOn = DateTime.Now,
                    Title = Guid.NewGuid().ToString(),
                    Url = fileUrl,
                    ProductId = product.Id,
                };

                product.Pictures.Add(img);

                this.repository.Add(img);
            }


            await this.repository.SaveChangesAsync();

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


        public async Task<IEnumerable<TViewModel>> GetImageCollectionlByProductIdsAsynq<TViewModel>(int id)
            => await this.repository.All()
            .Where(x => x.ProductId == id)
            .To<TViewModel>()
            .ToListAsync();
    }
}
