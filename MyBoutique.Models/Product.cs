using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Models
{
    public class Product : BaseDeletableModel<int>
    {
        public Product()
        {
            this.Pictures = new List<Picture>();
        }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 4)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string CategoryName { get; set; }


        [Required]
        public string CategoryType { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public ICollection<Picture> Pictures { get; set; }
    }
}
