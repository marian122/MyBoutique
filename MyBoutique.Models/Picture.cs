using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        public string Url { get; set; }

        public string Title { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
