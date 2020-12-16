using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MyBoutique.Common.Repositories;
using MyBoutique.Data;
using MyBoutique.Data.Repositories;
using MyBoutique.Models;
using MyBoutique.Services;
using System.Text;

namespace MyBoutique
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderDataService, OrderDataService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();

            return services;
        }

        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            return services;
        }

        public static IServiceCollection RegisterCloudinary(this IServiceCollection services, IConfiguration configuration)
        {
            Account account = new Account(
               configuration["CloudinaryCloudName"],
               configuration["CloudinaryApiKey"],
              configuration["CloudinaryApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);

            services.AddSingleton(cloudinary);

            return services;
        }
    }
}
