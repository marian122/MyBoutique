using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Services;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Infrastructure.InputModels;

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

            if (!this.ModelState.IsValid)
            {
                return this.Ok(this.ModelState.Values);
            }

            //input.Photos = files;
            var result = await this.productService.CreateProductAsync(input);


            if (result)
            {
                return this.Ok(result);
            }

            return this.BadRequest("Failed to create product");
        }

        // EDIT api/<ProductsController>/edit/{productId}
        [HttpGet("edit/{productId}")]
        public async Task<IActionResult> Edit(int productId)
        {
            var result = await this.productService.GetProductForEditAsync(productId);

            return this.Ok();
        }

        [HttpPut("edit/{productId}")]
        public async Task<IActionResult> Edit(int productId, EditProductInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Ok(input);
            }

            var result = await this.productService.EditProductAsync(productId, input);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest();
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
