using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class CategoryType : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Name { get; set; }

    }
}
