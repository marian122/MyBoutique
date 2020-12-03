using System.Collections.Generic;

namespace MyBoutique.Infrastructure.ViewModels.Collections
{
    public class OrdersViewModel
    {
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
