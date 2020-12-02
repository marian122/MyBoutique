using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBoutique.Infrastructure.InputModels
{
    public class CreateImageInputModel
    {
        public string Title { get; set; }

        public IFormFile File { get; set; }
    }
}
