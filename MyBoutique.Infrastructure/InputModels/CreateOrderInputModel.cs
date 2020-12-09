using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateOrderInputModel
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
