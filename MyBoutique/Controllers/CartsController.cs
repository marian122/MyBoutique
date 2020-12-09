using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructure.InputModels;
using MyBoutique.Services;
using MyBoutique.Infrastructure.ViewModels;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        // GET: api/<CartsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = this.cartService.AllOrders<CartViewModel>();

            if (!result.Any())
            {
                return this.NoContent();
            }
            return this.Ok(result);
        }

        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await this.cartService.GetOrderByIdAsynq<OrderViewModel>(id);

            if (order != null)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to load order with id={id} from db");
        }

        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GetOrdersBySessionId(string sessionId)
        {
            var order = await this.cartService.GetAllCartOrderBySessionId<OrderViewModel>(sessionId);

            if (order != null)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to load order with sessionId={sessionId} from db");
        }

        // POST api/<CartsController>/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCartInputModel inputModel)
        {

            if (!this.ModelState.IsValid)
            {
                return this.UnprocessableEntity(this.ModelState.Values);
            }

            try
            {
                var orderCart = await this.cartService.MakeOrderCartAsync<OrderViewModel>(inputModel);

                if (orderCart != 0)
                {
                    return this.Ok(orderCart);
                }
            }
            catch (Exception a)
            {
                return this.BadRequest(a.Message);
            }

            return this.BadRequest($"Failed to load order from db");
        }

    }
}
