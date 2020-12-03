using MyBoutique.Mappings;
using MyBoutique.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Infrastructure.ViewModels
{
    public class OrderDataViewModel : IMapFrom<OrderData>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }

        public string PromoCode { get; set; }
    }
}
