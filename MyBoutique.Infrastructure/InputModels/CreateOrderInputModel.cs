using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateOrderInputModel
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Size { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        
    }
}
