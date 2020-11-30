using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Services;
using MyBoutique.ViewModels;

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
            var result = await this.cartService.GetAllOrdersAsync<OrderViewModel>();
            return this.Ok(result);
        }

        // TODO: Implement to display orders only for current session id.

        // GET api/<CartsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await this.cartService.GetOrderByIdAsync<OrderViewModel>(id);

            if (order != null)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to load order with id={id} from db");
        }

    }
}
