using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBoutique.Services
{
    public interface ICartService
    {
        public Task<int> MakeOrderCartAsync<TViewModel>();
    }
}
