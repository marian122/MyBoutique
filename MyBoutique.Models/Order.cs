using MyBoutique.Common.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Models
{
    public class Order : BaseDeletableModel<int>
    {
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string UserId { get; set; }


        [Required]
        public string Color { get; set; }

        [Required]
        public string Size  { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public string PicUrl { get; set; }
    }
}
