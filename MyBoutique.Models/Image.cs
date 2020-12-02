using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBoutique.Models
{
    public class Image
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string  Path { get; set; }

        [Required]
        public string Format { get; set; }

        [Required]
        public byte[] Content { get; set; }
    }
}
