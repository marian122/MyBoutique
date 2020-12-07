using Microsoft.EntityFrameworkCore;
using MyBoutique.Common.Repositories;
using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<CategoryType> categoryRepository;

        public CategoryService(IDeletableEntityRepository<CategoryType> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<TViewModel>> GetAllCategories<TViewModel>()
        => await this.categoryRepository
            .All()
            .Where(x => x.IsDeleted == false)
            .To<TViewModel>()
            .ToListAsync();
    }
}
