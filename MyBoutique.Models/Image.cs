using MyBoutique.Common.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class Image : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(80, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string  Path { get; set; }

        public string Format { get; set; }

        public string Alt { get; set; }
    }
}
