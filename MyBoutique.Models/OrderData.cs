using MyBoutique.Common.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Models
{
    public class OrderData : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string FirstName { get; set; }
        

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string City { get; set; }
        
        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Address { get; set; }


        //[Required]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string DeliveryType { get; set; }

        [MaxLength(350)]
        public string AdditionalInformation { get; set; }

        public decimal SubTotal { get; set; }
        
        public string PromoCode { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
