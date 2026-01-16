using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")] //URL will be api/products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult WelcomeMessage()
        {
            return Ok("Welcome to Muthu Dev Hub Channel!");
        }
    }
}
