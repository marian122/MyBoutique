using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class CategoryViewModel : IMapFrom<CategoryType>
    {
        public string Name { get; set; }
    }
}
