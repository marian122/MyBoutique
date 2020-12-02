using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Models
{
    public class Model : BaseDeletableModel<int>
    {
        public string  Size { get; set; }

        public string Color { get; set; }
    }
}
