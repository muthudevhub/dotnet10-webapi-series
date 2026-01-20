using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")] //URL will be api/products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("welcome")]
        public IActionResult WelcomeMessage()
        {
            return Ok("Welcome to Muthu Dev Hub Channel!");
        }
        [HttpGet("All")]
        public IActionResult GetAllProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Product 1", Price = 10.0m, Description = "Description for Product 1" },
                new { Id = 2, Name = "Product 2", Price = 20.0m, Description = "Description for Product 2" },
                new { Id = 3, Name = "Product 3", Price = 30.0m, Description = "Description for Product 3" }
            };
            return Ok(products);
        }



    }
}
