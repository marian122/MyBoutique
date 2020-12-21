using System;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrdersController(IOrderService orderService, IHttpContextAccessor httpContextAccessor)
        {
            this.orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }


        // POST: api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateOrderInputModel input)
        {

            if (this.ModelState.IsValid)
            {
                try
                {
                    //input.UserId = sessionId;
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

        // DELETE api/<OrdersController>/clear/{userId}
        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> DeleteByUserId(string userId)
        {
            var order = await this.orderService.DeleteCurrentUserOrderAsync(userId);

            if (order)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to delete orders.");
        }

        // DELETE api/<OrdersController>
        [HttpDelete()]
        public async Task<IActionResult> Delete()
        {
            var order = await this.orderService.DeleteAllOrdersAsync();

            if (order)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to delete orders.");
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

            var sessionId = this.httpContextAccessor.HttpContext.Request.Cookies["cookie-name"];

            var result = await this.orderService.GetAllOrdersAsync<OrderViewModel>(sessionId);
            
            if (result == null)
            {
                return this.NoContent();
            }

            return this.Ok(result);
        }
    }
}
