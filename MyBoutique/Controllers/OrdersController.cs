using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Services;
using MyBoutique.Infrastructure.ViewModels;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // POST: api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateOrderInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.orderService.CreateOrderAsync(input);

                    if (result)
                    {
                        return this.Ok(result);
                    }

                }
                catch (Exception e)
                {

                    return this.BadRequest(e.Message);
                }
            }
          
            return this.BadRequest("Failed to create order");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await this.orderService.DeleteOrderAsync(id);

            if (order)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to delete order.");
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await this.orderService.GetOrderByIdAsync<OrderViewModel>(id);

            if (order != null)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to load order with id={id} from db");
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.orderService.GetAllOrdersAsync<OrderViewModel>();

            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }
    }
}
