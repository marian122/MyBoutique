using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBoutique.Infrastructure.ViewModels;
using MyBoutique.Infrastructures.InputModels;
using MyBoutique.Services;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        // GET: api/<ModelController>
        public async Task<IActionResult> Get()
        {
            var result = await this.modelService.GetAllModelsAsync<OrderViewModel>();

            if (result == null)
            {
                return this.NoContent();
            }
            return this.Ok(result);
        }
        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderData = await this.modelService.GetModelByIdAsynq<ModelViewModel>(id);

            if (orderData != null)
            {
                return this.Ok(orderData);
            }

            return this.BadRequest($"Failed to load model with id={id} from db");
        }

        // POST api/<ModelController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateModelInputModel input)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    var result = await this.modelService.CreateModelAsynq(input);

                    if (result != 0)
                    {
                        return this.Ok(result);
                    }

                }
                catch (Exception e)
                {

                    return this.BadRequest(e.Message);
                }
            }

            return this.BadRequest("Failed to create model");
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await this.modelService.DeleteModelAsynq(id);

            if (order)
            {
                return this.Ok(order);
            }

            return this.BadRequest($"Failed to delete model.");
        }
    }
}
