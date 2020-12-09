using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class Cart : BaseDeletableModel<int>
    {
        public virtual ICollection<Order> Orders { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal TotalPrice { get; set; }

        [Required]
        public int OrderDataId { get; set; }

        public OrderData OrderData { get; set; }

        public string SessionId { get; set; }

    }
}
