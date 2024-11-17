using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_framework.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<string> Products = new() { "Laptop", "Phone", "Tablet" };

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0 || id >= Products.Count)
                return NotFound(new { message = "Product not found." });

            return Ok(Products[id]);
        }
    }
}
