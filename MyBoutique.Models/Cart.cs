using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class Cart : BaseDeletableModel<int>
    {
        public virtual ICollection<Order> Orders { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
