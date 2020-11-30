using MyBoutique.Mappings;
using MyBoutique.Models;

namespace MyBoutique.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryType CategoryType { get; set; }

        public decimal Price { get; set; }

        //Collection of pics
    }
}
