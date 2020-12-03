using System.Collections.Generic;

namespace MyBoutique.Infrastructure.ViewModels.Collections
{
    public class ProductsViewModel
    {
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
