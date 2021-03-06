﻿using System;
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
        public async Task<IActionResult> Get(int Id)
        {
            var result = await this.imageService.GetImageCollectionlByProductIdsAsynq<ImageViewModel>(Id);

            if (result.Any())
            {
                return this.Ok(result);

            }
            return this.BadRequest();
        }

        // POST api/<ImageController>
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Post()
        {
            try
            {
                var files = Request.Form.Files;

                var imgs = await this.imageService
                .CreateImageCollectionAsynq(files);

                if (imgs)
                {
                    return this.Ok(imgs);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}
