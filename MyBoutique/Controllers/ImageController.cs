using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        // GET api/<imageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var image = await this.imageService.GetImagelByIdAsynq<ImageViewModel>(id);

            if (image != null)
            {
                return this.Ok(image);
            }

            return this.BadRequest($"Failed to load image with id={id} from db");
        }

        // POST api/<imageController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateImageInputModel input)
        {
            input.File = Request.Form.Files;

            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.imageService.CreateImageAsynq(input);

                    if (result != 0)
                    {
                        return this.Ok(result);
                    }

                }
                catch (Exception e)
                {

                    return this.BadRequest(e.Message);
                }
            }

            return this.BadRequest("Failed to create image");
        }

        // DELETE api/<imageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var image = await this.imageService.DeleteImageAsynq(id);

            if (image)
            {
                return this.Ok(image);
            }

            return this.BadRequest($"Failed to delete image.");
        }
    }
}
