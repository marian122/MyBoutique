using Microsoft.AspNetCore.Http;

namespace MyBoutique.Infrastructure.InputModels
{
    public class CreateImageInputModel
    {
        public string Title { get; set; }

        public IFormFileCollection File { get; set; }
    }
}
