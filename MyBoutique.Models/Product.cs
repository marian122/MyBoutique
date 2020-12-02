using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Photos = new List<Image>();
        }

        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 4)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryTypeId { get; set; }

        public CategoryType CategoryType { get; set; }

        [Required]
        public int ModelId { get; set; }

        public Model Model { get; set; }

        public ICollection<Image> Photos { get; set; }
    }
}
