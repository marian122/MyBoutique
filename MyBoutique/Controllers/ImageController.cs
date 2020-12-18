using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


        // GET api/<ImageController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ImageViewModel>> Get([FromBody] IList<int> Ids)
        {
            return await this.imageService.GetImageCollectionlByIdsAsynq<ImageViewModel>(Ids);
        }

        // POST api/<ImageController>
        [HttpPost(), DisableRequestSizeLimit]
        public async Task<IActionResult> Post()
        {
            var files = Request.Form.Files;
            if (files == null )
            {
                return this.UnprocessableEntity();
            }

            var imgs = await this.imageService
                .CreateImageCollectionAsynq(files);

            if (imgs != null)
            {
                return this.Ok(imgs);
            }

             return this.UnprocessableEntity();
        }
    }
}
