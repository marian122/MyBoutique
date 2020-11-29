using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        //Collection of pics
    }
}
