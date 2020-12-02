using MyBoutique.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet <CategoryType> Categories { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<OrderData> OrderDatas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
