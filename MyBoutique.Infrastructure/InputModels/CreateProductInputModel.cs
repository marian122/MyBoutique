namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateProductInputModel
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string CategoryType { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        //Collection of pics
    }
}
