using MyBoutique.Mappings;
using MyBoutique.Models;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class ImageViewModel : IMapFrom<Image>
    {
        public string Title { get; set; }

        public string Path { get; set; }

    }
}
