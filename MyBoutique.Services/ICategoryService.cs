using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<TViewModel>> GetAllCategories<TViewModel>();
        


    }
}
