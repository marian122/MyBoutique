using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Photos = new List<Image>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryTypeId { get; set; }

        public CategoryType CategoryType { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public ICollection<Image> Photos { get; set; }
    }
}
