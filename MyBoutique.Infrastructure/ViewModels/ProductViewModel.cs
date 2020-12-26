using AutoMapper;
using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string CategoryType { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public decimal Price { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        
    }

}
