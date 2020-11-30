using MyBoutique.Models;
namespace MyBoutique.Services.InputModels
{
    public class CreateProductInputModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        //Collection of pics
    }
}
