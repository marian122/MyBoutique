using Microsoft.AspNetCore.Http;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateProductInputModel
    {
        public int Id { get; set; }

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
        public string CategoryName { get; set; }

        [Required]
        public string CategoryType { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

        public CreateImageInputModel Photos { get; set; }
    }
}
