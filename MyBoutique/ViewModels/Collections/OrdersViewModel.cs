using System.Collections.Generic;

namespace MyBoutique.ViewModels.Collections
{
    public class OrdersViewModel
    {
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
