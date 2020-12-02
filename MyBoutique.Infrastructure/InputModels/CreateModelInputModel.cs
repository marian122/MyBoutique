using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Infrastructures.InputModels
{
    public class CreateModelInputModel
    {
        [StringLength(10, MinimumLength = 1)]
        public string Size { get; set; }

        [StringLength(80, MinimumLength = 4)]
        public string Color { get; set; }
    }
}
