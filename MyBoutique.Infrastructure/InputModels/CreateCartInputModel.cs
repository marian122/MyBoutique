using MyBoutique.Infrastructures.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructure.InputModels
{
    public class CreateCartInputModel
    {
        public virtual ICollection<CreateOrderInputModel> Orders { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal TotalPrice { get; set; }

        public int OrderDataId { get; set; }
    }
}
