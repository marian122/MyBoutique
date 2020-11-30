using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoutique.ViewModels
{
    public class CartViewModel : IMapFrom<Cart>
    {
        public virtual ICollection<Order> Orders { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
