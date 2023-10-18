using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutenticacionCookieControladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProtetedController : ControllerBase
    {
        static List<object> data = new List<object>();

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }
        

        [HttpPost]
        public IActionResult Post(string name, string lastName)
        {
            data.Add(new { name, lastName });

            return Ok();
        }
    }
}
