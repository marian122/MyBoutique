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
        public string City { get; set; }
        
        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Address { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string DeliveryType { get; set; }

        public string AdditionalInformation { get; set; }

        public decimal SubTotal { get; set; }

        public string PromoCode { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
