using MyBoutique.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBoutique.Infrastructure.InputModels
{
    public class OrderDataInputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }


        [Required]
        public string Phone { get; set; }

        [Required]
        public string DeliveryType { get; set; }

        [MaxLength(350)]
        public string AdditionalInformation { get; set; }

        public string UserId  { get; set; }

        public string PromoCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
