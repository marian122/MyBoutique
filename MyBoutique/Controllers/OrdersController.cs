using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Services;
using MyBoutique.ViewModels;

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
            var result = await this.orderService.CreateOrderAsync(input);

            if (result)
            {
                return this.Ok(result);
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
    }
}
