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

        public static IServiceCollection RegisterIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication()
               .AddCookie()
               .AddJwtBearer(cfg =>
               {
                   cfg.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidIssuer = configuration["Tokens:Issuer"],
                       ValidAudience = configuration["Tokens:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
                   };
               });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;

            });

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
