using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class CategoryType : BaseDeletableModel<int>
    {
        public string Name { get; set; }

    }
}
