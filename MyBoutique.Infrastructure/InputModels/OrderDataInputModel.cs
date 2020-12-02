using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Infrastructure.InputModels
{
    public class OrderDataInputModel
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
