using Microsoft.AspNetCore.Http;
using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class EditProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string CategoryType { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public IFormFileCollection Photos { get; set; }
    }
}
