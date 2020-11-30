using System.Collections.Generic;

namespace MyBoutique.ViewModels.Collections
{
    public class ProductsViewModel
    {
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
