using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")] //URL will be api/products
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 10.0m,
                Description = "Description for Product 1",
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Price = 20.0m,
                Description = "Description for Product 2",
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Price = 30.0m,
                Description = "Description for Product 3",
            },
        };

        [HttpGet("welcome")]
        public IActionResult WelcomeMessage()
        {
            return Ok("Welcome to Muthu Dev Hub Channel!");
        }

        [HttpGet("All")]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            products.Add(product);
            return Ok(products);
        }
    }
}
