using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        [HttpGet("set/{data}")]
        public IActionResult setsession(string data)
        {
            HttpContext.Session.SetString("keyname", data);
            return this.Ok("session data set");
        }

        [HttpGet("get")]
        public IActionResult getsessiondata()
        {
            var sessionData = HttpContext.Session.GetString("keyname");
            return this.Ok(sessionData);
        }
    }
}
