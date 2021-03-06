﻿using MyBoutique.Mappings;
using MyBoutique.Models;
using System.Collections.Generic;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class OrderDataViewModel : IMapFrom<OrderData>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }


        public int Phone { get; set; }

        public string AdditionalInformation { get; set; }

        public string DeliveryType { get; set; }

        public string PromoCode { get; set; }

        public decimal SubTotal { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
