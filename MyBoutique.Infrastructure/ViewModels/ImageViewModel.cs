using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Title { get; set; }

        public string Path { get; set; }

    }
}
