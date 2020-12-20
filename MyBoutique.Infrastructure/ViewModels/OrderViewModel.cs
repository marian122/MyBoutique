using MyBoutique.Mappings;
using MyBoutique.Models;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class OrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }
 
        public int ProductId { get; set; }
        
        public Product Product { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public string UserId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
