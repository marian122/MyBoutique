using MyBoutique.Mappings;
using MyBoutique.Models;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class ImageViewModel : IMapFrom<Picture>
    {
        public string Title { get; set; }

        public string Url { get; set; }

    }
}
