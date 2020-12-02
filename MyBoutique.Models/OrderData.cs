using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class OrderData : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string LastName { get; set; }


        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Adress { get; set; }


        [Required]
        [Phone]
        public string Phone { get; set; }


        [Required]
        [MaxLength(8)]
        public string PromoCode { get; set; }
    }
}
