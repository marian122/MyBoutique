﻿using MyBoutique.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateProductInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(350, MinimumLength = 4)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Category Type is required")]
        public string CategoryType { get; set; }

        public ICollection<Size> Sizes { get; set; }

        public ICollection<Color> Colors { get; set; }

    }
}
