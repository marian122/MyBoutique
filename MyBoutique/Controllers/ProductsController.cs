﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Services;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Infrastructure.InputModels;
using System.Net.Http;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Net;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        //public static string sessionData = Guid.NewGuid().ToString();

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var sessionData = Dns.GetHostEntry(Dns.GetHostName()).AddressList.GetValue(0).ToString();

            ////create new session here
            ////var sessionData = Guid.NewGuid().ToString();
            //HttpContext.Session.SetString("visitor", sessionData);

            var result = await this.productService.GetAllProductsAsync<ProductViewModel>();
            return this.Ok(result);
        }



        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var product = await this.productService.GetByIdAsync<ProductViewModel>(id);

            if (product != null)
            {
                return this.Ok(product);
            }

            return this.BadRequest($"Failed to load product with id={id} from db");
        }

        // POST: api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductInputModel input)
        {
            //IFormFileCollection files = this.HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return this.Ok(ModelState.Values);
            }

            //input.Photos = files;
            var result = await this.productService.CreateProductAsync(input);


            if (result)
            {
                return this.Ok(result);
            }

            return this.BadRequest("Failed to create product");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await this.productService.DeleteProductAsync(id);

            if (product)
            {
                return this.Ok(product);
            }

            return this.BadRequest($"Failed to delete product.");
        }

    }
}
