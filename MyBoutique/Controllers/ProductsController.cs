using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Services;
using MyBoutique.Services.InputModels;
using MyBoutique.ViewModels;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.productService.GetAllProductsAsync<ProductViewModel>();
            return this.Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> Post([FromBody]CreateProductInputModel input)
        {
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
