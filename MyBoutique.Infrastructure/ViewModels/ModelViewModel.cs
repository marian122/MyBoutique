using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class ModelViewModel : IMapFrom<Model>, IMapTo<Model>
    {
        public string Size { get; set; }

        public string Color { get; set; }
    }
}
